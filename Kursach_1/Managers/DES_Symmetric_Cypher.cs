using System.Text;
using System.Security.Cryptography;

namespace Kursach_1.Managers
{
    internal class DES_Symmetric_Cypher
    {
        public void Encrypt_DES(string Password)
        {
            FileStream fsInput = new FileStream("DES_sym_in.txt", FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream("DES_sym_out1.txt", FileMode.Create, FileAccess.Write);

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(Password);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(Password);

                ICryptoTransform desEncrypt = DES.CreateEncryptor();
                CryptoStream cs = new CryptoStream(fsEncrypted, desEncrypt, CryptoStreamMode.Write);

                byte[] bytearrayinput = new byte[fsInput.Length - 0];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cs.Write(bytearrayinput, 0, bytearrayinput.Length);
                cs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            fsInput.Close();
            fsEncrypted.Close();
            return;
        }

        public void Decrypt_DES(string Password)
        {
            FileStream fsInput = new FileStream("DES_sym_out1.txt", FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream("DES_sym_out2.txt", FileMode.Create, FileAccess.Write);

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(Password);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(Password);

                ICryptoTransform desEncrypt = DES.CreateDecryptor();
                CryptoStream cs = new CryptoStream(fsEncrypted, desEncrypt, CryptoStreamMode.Write);

                byte[] bytearrayinput = new byte[fsInput.Length - 0];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cs.Write(bytearrayinput, 0, bytearrayinput.Length);
                cs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            fsInput.Close();
            fsEncrypted.Close();
            return;
        }
    }
}
