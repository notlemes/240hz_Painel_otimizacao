namespace Painel240hz
{
    public static class LicenseManager
    {
        public static bool ValidateKey(string key)
        {
            // chave simples de teste
            if (key == "240HZ-ACCESS")
                return true;

            return false;
        }
    }
}