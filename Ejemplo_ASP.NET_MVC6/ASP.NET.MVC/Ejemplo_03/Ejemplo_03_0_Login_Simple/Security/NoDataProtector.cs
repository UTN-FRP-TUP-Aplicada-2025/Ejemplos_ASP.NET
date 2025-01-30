using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using System.Text.Json;

namespace Ejemplo_03_0_Login_Simple.Security;


using Microsoft.AspNetCore.DataProtection;

public class NoDataProtectionProvider : IDataProtectionProvider
{
    public IDataProtector CreateProtector(string purpose)
    {
        return new NoDataProtector();
    }

    private class NoDataProtector : IDataProtector
    {
        public byte[] Protect(byte[] plaintext)
        {
            return plaintext; // Sin cifrado
        }

        public byte[] Unprotect(byte[] protectedData)
        {
            return protectedData; // Sin descifrado
        }

        public IDataProtector CreateProtector(string purpose)
        {
            return this;
        }
    }
}

