using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class AssembliesCollector
    {


        private string[] Dlls;
        private byte[] SHAKey = BitConverter.GetBytes(0x67452301EFCDAB89);
        List<string> DllList;

        public List<string> GetRightFiguresAssemblies(string path)
        {
            try
            {
                Dlls = Directory.GetFiles(path, "*.dll");
                DllList = new List<string>();
                foreach (var lib in Dlls)
                {
                    //AddHash(lib, SHAKey);
                    //DllList.Add(lib);
                    if (CheckingAssemblySignature(lib, SHAKey)) DllList.Add(lib);
                    else MessageBoxWrongDll("Error of connecting " + lib.ToString() + " to application: wrong file.");
                }            
            }
            catch (Exception e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(e.Message, "Error!.", buttons);
            }
            return DllList;
        }

        private void MessageBoxWrongDll(string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, "Assembly error.", buttons);
        }

        private bool CheckingAssemblySignature(string asm, byte[] key)
        {
            FileStream file = new FileStream(asm, FileMode.Open, FileAccess.ReadWrite);
            if (file.Length < 20) return false;
            byte[] readhash = new byte[40];
            file.Seek(-40, SeekOrigin.End);
            file.Read(readhash, 0, 40);
            file.Close();
            RemoveByte(asm, 40);
            byte[] decrhash = new byte[20];
            decrhash = DecryptHashByRSA(readhash, 343, 55973);

            file = new FileStream(asm, FileMode.Open, FileAccess.ReadWrite);
            HMACSHA1 hmac = new HMACSHA1(key);
            byte[] hashValue = hmac.ComputeHash(file);
            file.Seek(0, SeekOrigin.End);
            file.Write(readhash, 0, 40);
            file.Close();

            for (int i = 1; i < 20; i++)
                if (hashValue[i] != decrhash[i]) return false;
            return true;
        }

        private void RemoveByte(string file, int countOfByte)
        {
            var bData = File.ReadAllBytes(file);
            Array.Resize(ref bData, bData.Length - countOfByte);
            File.WriteAllBytes(file, bData);
        }

        private byte[] DecryptHashByRSA(byte[] hash, ulong exp, ulong prod)
        {
            byte[] dechash = new byte[20];
            for (int i = 0; i < 20; i++)
            {
                ulong temp = 0;
                temp = temp | hash[i * 2 + 0];
                temp = temp << 8;
                temp = temp | hash[i * 2 + 1];
                ulong rez = FastExp(temp, exp, prod);
                dechash[i] = (byte)rez;
            }
            return dechash;
        }

        private ulong FastExp(ulong a, ulong z, ulong n)
        {
            ulong a1 = a;
            ulong z1 = z;
            ulong x = 1;
            while (z1 != 0)
            {
                while (z1 % 2 == 0)
                {
                    z1 = z1 / 2;
                    a1 = (a1 * a1) % n;
                }
                z1 = z1 - 1;
                x = ((x * a1) + n) % n;
            }
            return x;
        }

        private byte[] EncryptHashByRSA(byte[] hash, ulong exp, ulong prod)
        {
            byte[] crhash = new byte[40];
            for (int i = 0; i < 20; i++)
            {
                ulong word = FastExp(hash[i], exp, prod);
                byte byte1 = (byte)(word >> 8);
                byte byte2 = (byte)word;
                crhash[i * 2 + 0] = byte1;
                crhash[i * 2 + 1] = byte2;
            }
            return crhash;
        }

        private void AddHash(string asm, byte[] key)
        {
            FileStream file = new FileStream(asm, FileMode.Open, FileAccess.Read);
            HMACSHA1 hmac = new HMACSHA1(key);
            byte[] hashValue = hmac.ComputeHash(file);
            file.Close();

            file = new FileStream(asm, FileMode.Append, FileAccess.Write);
            byte[] cryptedHash = EncryptHashByRSA(hashValue, 4207, 55973);
            file.Write(cryptedHash, 0, cryptedHash.Length);
            file.Close();
        }
    }
}
