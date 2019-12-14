using System;
using System.Collections.Generic;
using System.Text;

namespace eximo.data.Services
{
    public interface IEncryptionService
    {
        byte[] Encrypt<T>(T value);
        string Decrypt<T>(byte[] value);
    }
}
