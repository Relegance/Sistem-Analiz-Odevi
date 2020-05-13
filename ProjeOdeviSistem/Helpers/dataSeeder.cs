using ProjeOdeviSistem.Helper;
using ProjeOdeviSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeOdeviSistem.Helpers
{
    public class dataSeeder
    {
        private helperUser user { get; set; }
        private helperCategories cat { get; set; }
        private helperProducts pro { get; set; }
        public dataSeeder(helperUser us,helperProducts pro, helperCategories cat)
        {
            this.user = us;
            this.cat = cat;
            this.pro = pro;
        }
        public void userSeeder()
        {
            List<User> list = new List<User>();
            list.Add(new User("Cihan Enes Çolak","123456","cihan","istanbul","adres","admin"));

            foreach (var item in list)
            {
                user.Create(item);
            }
        }

        public void productSeeder()
        {
            List<Categorie> categories = new List<Categorie>();
            List<Product> products = new List<Product>();

            categories.Add(new Categorie("Cep Telefonu"));
            categories.Add(new Categorie("Bilgisayar"));
            categories.Add(new Categorie("Market"));
            categories.Add(new Categorie("Elektronik"));
            categories.Add(new Categorie("Beyaz Eşya"));
            foreach (var item in categories)
            {
                cat.Create(item);
            }

            products.Add(new Product("Hp 14-CF2005NT Core i7","Amd Radeon 530, Core i7 10510U, 8GB DDR4 Ram, 512GB SSD",5899, "https://productimages.hepsiburada.net/s/38/550/10577819926578.jpg/format:webp","Bilgisayar"));
            products.Add(new Product("Dell G315 Core i7","Gtx1660ti, i7 9750H, 8GB DDR4 Ram, 256GB SSD",8699, "https://productimages.hepsiburada.net/s/37/550/10558514397234.jpg/format:webp","Bilgisayar"));
            products.Add(new Product("Hp Elite Dragonfly","i5 8265U, 8GB DRR4 Ram, 256GB SSD",12999, "https://productimages.hepsiburada.net/s/37/550/10542939111474.jpg/format:webp","Bilgisayar"));
            products.Add(new Product("Lenovo Legion Y540","Gtx1660ti, i7 9750H, 16GB DDR4 Ram, 256GB SSD",11499, "https://productimages.hepsiburada.net/s/30/550/10292354056242.jpg/format:webp","Bilgisayar"));
            products.Add(new Product("Alienware AWM17","Rtx2080, i7 9750H, 16GB DDR4 Ram, 512 GB SSD",25219, "https://productimages.hepsiburada.net/s/32/550/10387819855922.jpg/format:webp","Bilgisayar"));
            products.Add(new Product("Huawei P30 Lite", "Şık ve Estetik Tasarım, Güçlü ve Kaliteli Performans",2599, "https://productimages.hepsiburada.net/s/27/550/10194864242738.jpg/format:webp","Cep Telefonu"));
            products.Add(new Product("Iphone 11 Pro","Pro kameralar.Pro ekran.Pro performans",10439, "https://productimages.hepsiburada.net/s/32/550/10352810393650.jpg/format:webp","Cep Telefonu"));
            products.Add(new Product("Samsung Galaxy Note 10 Lite","128 GB Depolama ve Samsung garantisi",4699, "https://productimages.hepsiburada.net/s/36/550/10503082868786.jpg/format:webp","Cep Telefonu"));
            products.Add(new Product("Xiaomi Redmi Note 8 Pro","64 GB Depolama ve Xiaomi garantisi",2699, "https://productimages.hepsiburada.net/s/31/550/10333325459506.jpg/format:webp","Cep Telefonu"));
            products.Add(new Product("Ethem Efendi Sızma Zeytinyağı","5Lt",99, "https://productimages.hepsiburada.net/s/38/550/10596310122546.jpg/format:webp","Market"));
            products.Add(new Product("Hellmann's 5'li Sos Paketi","5li sos paketi",64, "https://productimages.hepsiburada.net/s/36/550/10503150207026.jpg/format:webp","Market"));
            products.Add(new Product("Koraplast Buzdolabı Poşeti","Orta bay 4 al 3 öde",17, "https://productimages.hepsiburada.net/s/6/550/9747356221490.jpg/format:webp","Market"));
            products.Add(new Product("Kurukahveci Mehmet Efendi Filtre","Colombian filtre kahve",43, "https://productimages.hepsiburada.net/s/6/550/9741866041394.jpg/format:webp","Market"));
            products.Add(new Product("Torku Toz Şeker","Kristal Şeker 5 kg",39.90, "https://productimages.hepsiburada.net/s/28/550/10214447087666.jpg/format:webp","Market"));
            products.Add(new Product("Ariel Toz Çamaşır Deterjanı","5+5 kg avantaj paketi",69.89, "https://productimages.hepsiburada.net/s/31/550/10290275811378.jpg/format:webp","Market"));
            products.Add(new Product("Finish Quantum Max 85","85 Kapsül ve özel saklama kutusu",164.90, "https://productimages.hepsiburada.net/s/37/550/10555507146802.jpg/format:webp","Market"));
            products.Add(new Product("Perwoll Siyahlar","Siyahlar için hassas yıkama 3lt",22.89, "https://productimages.hepsiburada.net/s/38/550/10604112117810.jpg/format:webp","Market"));
            products.Add(new Product("Siemens KG86NAI42N A+++","A+++ Buzdolabı, 682 lt ve no-Frost",7375, "https://productimages.hepsiburada.net/s/20/550/9897140027442.jpg/format:webp","Beyaz Eşya"));
            products.Add(new Product("Samsung RT38K5100WW","A+ Buzdolabı, 397 lt ve no-Frost",2479, "https://productimages.hepsiburada.net/s/19/550/9833207267378.jpg/format:webp","Beyaz Eşya"));
            products.Add(new Product("Bosch WGA142X0TR","A+++, 9kg , 1200 Devir",3099, "https://productimages.hepsiburada.net/s/35/550/10475517739058.jpg/format:webp","Beyaz Eşya"));
            products.Add(new Product("Samsung WW90J5475FW","A+++, 9kg, 1400 Devir",2529, "https://productimages.hepsiburada.net/s/19/550/9860566581298.jpg/format:webp","Beyaz Eşya"));
            products.Add(new Product("Hoover 3lü Ankastre","fırın ocak ve dazlumbaz seti",2499, "https://productimages.hepsiburada.net/s/26/550/10139685290034.jpg/format:webp","Beyaz Eşya"));
            products.Add(new Product("Simfer Oscar 3lü Ankastre","fırın ocak ve dazlumbaz seti",1799, "https://productimages.hepsiburada.net/s/2/550/9551216705586.jpg/format:webp","Beyaz Eşya"));
            products.Add(new Product("Grunding GDF 6502","A++ 6 Programlı Bulaşık Makinesi",1749, "https://productimages.hepsiburada.net/s/31/550/10331866660914.jpg/format:webp","Beyaz Eşya"));
            products.Add(new Product("Vestel BM-401","A++ 4 Programlı Bulaşık Makinesi",1529, "https://productimages.hepsiburada.net/s/20/550/9872854777906.jpg/format:webp","Beyaz Eşya"));
            products.Add(new Product("Samsung GE83X/AND","23 lt Mikrodalga Fırın",669, "https://productimages.hepsiburada.net/s/21/550/9926748635186.jpg/format:webp","Beyaz Eşya"));
            products.Add(new Product("Grunding GDH 92","A++ 9kg Kurutma Makinesi",2649, "https://productimages.hepsiburada.net/s/32/550/10367187615794.jpg/format:webp","Beyaz Eşya"));
            products.Add(new Product("Siemens Dw15701","Soğuk ılık alttan damacanalı su sebili",1154, "https://productimages.hepsiburada.net/s/37/550/10565701828658.jpg/format:webp","Beyaz Eşya"));

            foreach (var item in products)
            {
                pro.Create(item);
            }


        }
    }
}
