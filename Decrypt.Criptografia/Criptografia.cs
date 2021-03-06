﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Decrypt.Criptografia
{
    public class Criptografia
    {
        public static string Criptografar(string word)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(word);

                //System.Configuration.AppSettingsReader settingsReader =
                //                                    new AppSettingsReader();
                // Get the key from config file

                string key = "g4solucoesom30sistemaima";
                //System.Windows.Forms.MessageBox.Show(key);
                //If hashing use get hashcode regards to your key
                //if (useHashing)
                //{
                //    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                //    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //    //Always release the resources and flush data
                //    // of the Cryptographic service provide. Best Practice

                //    hashmd5.Clear();
                //}
                //else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes.
                //We choose ECB(Electronic code Book)
                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)

                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                //transform the specified region of bytes array to resultArray
                byte[] resultArray =
                  cTransform.TransformFinalBlock(toEncryptArray, 0,
                  toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor
                tdes.Clear();
                //Return the encrypted data into unreadable string format
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                //return "ENC" + word;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }


        }
        public static string Descriptografar(string word)
        {
            try
            {
                byte[] keyArray;
                //get the byte code of the string

                byte[] toEncryptArray = Convert.FromBase64String(word);


                //Get your key from config file to open the lock!
                string key = "g4solucoesom30sistemaima";


                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);


                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes. 
                //We choose ECB(Electronic code Book)

                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(
                                     toEncryptArray, 0, toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor                
                tdes.Clear();
                //return the Clear decrypted TEXT
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {

                return  ex.GetBaseException().Message;
            }
        }
    }
}
