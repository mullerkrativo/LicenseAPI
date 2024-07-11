using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Reliance.Core.Interfaces;
using Reliance.Data;
using Reliance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Web;
using System.Text.Json;
using Reliance.Core.Utilities.Helpers;


namespace Reliance.Core.Services
{
    public class SuperUserService : ISuperUserService
    {
        private RelianceDBContext _context;
        string Key = "8UHjPgXZzXCGkhxV2QCnooyJexUzvJrO";
        public SuperUserService(RelianceDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Licensetable> GetAllLicense(int Page)
        {
            return _context.Licensetables.Skip((Page - 1) * 20).Take(20);
        }

        public string CreateLicense(Licensetable model)
        {
                string LicenseKey;
                string _LicenseKeyParameter = model.AppCode + "_" + model.CustomerCode + "_" + model.LicenseStartDate + "_" + model.LicenseEndDate;
                LicenseKey = Aes256CbcEncrypter.Encrypt(_LicenseKeyParameter, Key);
                // validate
                if (_context.Licensetables.Any(x => x.AppCode.Trim().ToLower() == model.AppCode.Trim().ToLower() ))
                    throw new AppException("App already has a License Key");
                 Licensetable licensetable = new Licensetable
                 {
                AppCode = model.AppCode,
                CustomerCode=model.CustomerCode,
                Autonumber= "RIS" + _context.Licensetables.Count()+1,
                 CustomerAddress=model.CustomerAddress,
                  CustomerContact=model.CustomerContact,
                   CustomerName=model.CustomerName,
                   EntryDate=DateTime.Now,
                    LicenseEndDate=model.LicenseEndDate,
                     Licensekey=LicenseKey,
                      LicenseKeyParameter=_LicenseKeyParameter,
                       LicenseStartDate=model.LicenseStartDate,
                };
                _context.Add(licensetable);
                _context.SaveChanges();
                return LicenseKey;
        }
        class Aes256CbcEncrypter
        {
            private static readonly Encoding encoding = Encoding.UTF8;

            public static string Encrypt(string plainText, string key)
            {
                try
                {
                    Aes aes = Aes.Create();
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Mode = CipherMode.CBC;

                    aes.Key = encoding.GetBytes(key);
                    aes.GenerateIV();

                    ICryptoTransform AESEncrypt = aes.CreateEncryptor(aes.Key, aes.IV);
                    byte[] buffer = encoding.GetBytes(plainText);

                    string encryptedText = Convert.ToBase64String(AESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));

                    String mac = "";

                    mac = BitConverter.ToString(HmacSHA256(Convert.ToBase64String(aes.IV) + encryptedText, key)).Replace("-", "").ToLower();

                    var keyValues = new Dictionary<string,
                      object> {
    {
      "iv",
      Convert.ToBase64String(aes.IV)
    },
    {
      "value",
      encryptedText
    },
    {
      "mac",
      mac
    },
  };

                    return Convert.ToBase64String(encoding.GetBytes(JsonSerializer.Serialize(keyValues)));
                }
                catch (Exception e)
                {
                    throw new Exception("Error encrypting: " + e.Message);
                }
            }
            static byte[] HmacSHA256(String data, String key)
            {
                using (HMACSHA256 hmac = new HMACSHA256(encoding.GetBytes(key)))
                {
                    return hmac.ComputeHash(encoding.GetBytes(data));
                }
            }
        }
    }
    }
    
