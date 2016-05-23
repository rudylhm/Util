using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string privatekey = @"<RSAKeyValue><Modulus>wtRTodI57ndjSvs9oHpjGJVW9+i7ADpxDLPOeTVEeDmXfZOZIlnZmony/JYug2lcj/6TKZ1XStX8prdlM0no7bMAgxhLahqPLQonK/UBKr8wxsu8NPpZp87XezW005Wm6z6R2C9QiqboVGkt6bRn1S6mnt21EGXmk9hgjPsff08=</Modulus><Exponent>AQAB</Exponent><P>9qKefU4k++ntQbyGcFu7yBHUdZq6fcimDY8YC4PCUa1hlTiDO9D+ySTVgX70Fc+DPmtbtFQ9MNFelsw1IFYnAQ==</P><Q>yjojAunKDp3W0Lr2tjPnZ72XXgeSyLY1brtZa0cIQ57LSizEvR5uxkTGINfanBtidLb2abAPRmeDA/Z5gY92Tw==</Q><DP>BzXh5E/wjNzd7toQJCDKcKL0zyti4GKJWEQis9N6TuD+xVoNnCYUDNVi2JJZmHmkoKKK387GqzKzzTzTIMrkAQ==</DP><DQ>eQFml8Sq6ioaMxXcsFPIgLPakiI3+6/DszmZnO6JDGVFQWIeawd9w1e9skNXBRgBxtMACWeXDEq+A64FMLhWUw==</DQ><InverseQ>qSJtLAieo2IZfS0caSRewA9y5xQnHPw9ldG08IxP3XOwZiFJTiOnUrUaxydX7I/+EYc9PH2zM7gwpkZwGYGc9g==</InverseQ><D>aAuqKhYx9+bsMOPhcm1JtJw0WKqCC0oqi2UO0+4dhbMD8v0633xqWDxpdnjhmC5RT1jd0HCFaKLEjWgNdIl5CWBDtiR36tWRj34O5WS8fm+Ux1cNxo5nP4yqY1UAeRQmYdpD2zQfQsEEXLtbrsHyZJZq/e21Ab3aJwD+6PpvjgE=</D></RSAKeyValue>";
            string cStr = @"SdkPqJRzTfa7lfDwrJs/FbukYdRQUGWIniK4ExNN4sdRJ/E1hIPrhZl1u+z5VJ5FP99ZyrA/ohi9Bcww3VZN+ad28KJeNUsXf1vCqVJdK6ZEqpCcsAB4GWUI8l2E7WU3jB3kOB+IuBKVYS5iJg94mkJ4nkf1iiUutrpPPgytVvg=";
            string result = Util.Security.RSAUtil.RSADecrypt(privatekey, cStr);
        }
    }
}
