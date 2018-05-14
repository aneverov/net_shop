using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetShop_cw_47.Models;

namespace NetShop_cw_47
{
    public class ModelData
    {
        public static void Initialize(MobileContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "Samsung Galaxy S8",
                        Company = "Samsung",
                        Price = 900,
                        Features = "Операционная система    Android 7.0\nПамять 64 GB"
                    },
                    new Phone
                    {
                        Name = "iPhone 8",
                        Company = "Apple",
                        Price = 1000,
                        Features = "Операционная система    iOS\nПамять 128 GB"
                    },
                    new Phone
                    {
                        Name = "Google Pixel 2",
                        Company = "Google",
                        Price = 950,
                        Features = "Операционная система    Android 6.0\nПамять 32 GB"
                    }
                );
                context.SaveChanges();
            }
            else
            {
                int a = 5;
                int b = 16;
                foreach (Phone phone in context.Phones)
                {
                    if (phone.Company == "Apple")
                    {
                        phone.Features = "Операционная система iOS" + " Память " + b + " GB";
                    }
                    else
                    {
                        phone.Features = "Операционная система Android " + a + " Память " + b + " GB";
                    }
                    a++;
                    b = b * 2;
                }
                context.SaveChanges();
            }
        }

    }
}
