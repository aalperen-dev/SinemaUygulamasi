using System;

namespace SinemaUygulamasi
{
    class Program
    {
        static Sinema Snm;
        static void Main(string[] args)
        {
            Uygulama();
        }

        static void Uygulama()
        {
            Giris();
            Menu();

            while (true)
            {
                Console.WriteLine();
                string secim = SecimAl();
                Console.WriteLine();
                switch (secim)
                {
                    case "1":
                    case "S":
                        BiletSatis();
                        break;
                    case "2":
                    case "R":
                        BiletIadesi();
                        break;
                    case "3":
                    case "D":
                        DurumBilgisi();
                        break;
                    case "4":
                    case "X":
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void Giris()
        {
            Console.WriteLine("-------Butik Sinema Salonu-------");
            Console.Write("Film adı : ");
            string film = Console.ReadLine();
            Console.Write("Kapasite : ");
            int kap = int.Parse(Console.ReadLine());
            Console.Write("Tam Bilet Fiyatı : ");
            float tam = float.Parse(Console.ReadLine());
            Console.Write("Yarım Bilet Fiyatı : ");
            float yarim = float.Parse(Console.ReadLine());

            Snm = new Sinema(film, kap, tam, yarim);
        }
        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Bilet Sat(S)      ");
            Console.WriteLine("2 - Bilet İade(R)     ");
            Console.WriteLine("3 - Durum Bilgisi(D)  ");
            Console.WriteLine("4 - Çıkış(X)          ");
        }
        static string SecimAl()
        {
            int sayac = 0;
            string karakterler = "1234SRDX";

            while (true)
            {
                sayac++;
                Console.Write("Seçiminiz : ");
                string giris = Console.ReadLine().ToUpper();

                if (giris.Length == 1 && karakterler.IndexOf(giris) > -1)
                {
                    return giris;
                }
                else if (sayac == 10)
                {
                    Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                    Environment.Exit(0);
                }
                Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
            }
        }

        static void BiletSatis()
        {
            Console.WriteLine("Bilet Sat :        ");

            //yazdırmaları ve deger almaları metot ile yaptık.

            //Console.Write("Tam Bilet Adedi: ");
            //int tam = int.Parse(Console.ReadLine());
            int tam = SayiAl("Tam Bilet Adedi : ");

            //Console.Write("Yarım Bilet Adedi: ");
            //int yarim = int.Parse(Console.ReadLine());
            int yarim = SayiAl("Yarım Bilet Adedi : ");

            Snm.BiletSatis(tam, yarim);
        }


        static void BiletIadesi()
        {
            //yazdırmaları ve deger almaları metot ile yaptık.

            Console.WriteLine("Bilet Iade :        ");
            //Console.Write("Tam Bilet Adedi: ");
            //int tam = int.Parse(Console.ReadLine());
            int tam = SayiAl("Tam Bilet Adedi : ");

            //Console.Write("Yarım Bilet Adedi: ");
            //int yarim = int.Parse(Console.ReadLine());
            int yarim = SayiAl("Yarım Bilet Adedi : ");

            Snm.BiletIadesi(tam, yarim);
        }

        static int SayiAl(string mesaj)
        {
            int sayi1;
            while (true)
            {
                Console.Write(mesaj);
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi1))
                {
                    return sayi1;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı.");
                }
            }
        }

        static void DurumBilgisi()
        {
            Console.WriteLine("Durum Bilgisi");
            Console.WriteLine("Film : " + Snm.FilmAdi);
            Console.WriteLine("Kapasite : " + Snm.Kapasite);
            Console.WriteLine("Tam Bilet Fiyatı : " + Snm.TamBiletFiyati);
            Console.WriteLine("Yarım Bilet Fiyatı : " + Snm.YarimBiletFiyati);
            Console.WriteLine("Toplam Tam Bilet Adedi : " + Snm.ToplamTamBiletAdedi);
            Console.WriteLine("Toplam Yarım Bilet Adedi : " + Snm.ToplamYarimBiletAdedi);
            Console.WriteLine("Ciro : " + Snm.Ciro);
            Console.WriteLine("Boş koltuk adedi : " + Snm.BosKoltukAdediGetir());
        }
    }
}
