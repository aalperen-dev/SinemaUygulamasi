using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaUygulamasi
{
    class Sinema
    {
        public string FilmAdi { get; set; }
        public int Kapasite { get; }
        public float TamBiletFiyati { get; }
        public float YarimBiletFiyati { get; }
        public int ToplamTamBiletAdedi { get; private set; }
        public int ToplamYarimBiletAdedi { get; private set; }
        public float Ciro
        {
            get
            {
                float c = this.ToplamTamBiletAdedi * this.TamBiletFiyati + this.ToplamYarimBiletAdedi * this.YarimBiletFiyati;
                return c;
            }
        }

        public Sinema(string filmAdi, int kapasite, float tamBiletFiyati, float yarimBiletFiyati)
        {
            this.FilmAdi = filmAdi;
            this.Kapasite = kapasite;
            this.TamBiletFiyati = tamBiletFiyati;
            this.YarimBiletFiyati = yarimBiletFiyati;          
        }

        public void BiletSatis(int tamBiletAdedi, int yarimBiletAdedi)
        {
            if (BosKoltukAdediGetir() >= tamBiletAdedi + yarimBiletAdedi)
            {
                this.ToplamTamBiletAdedi += tamBiletAdedi;
                this.ToplamYarimBiletAdedi += yarimBiletAdedi;
                //CiroHesapla(); ciro get ile hesaplanıyor. metota gerek kalmadı.
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("Yeterli boş koltuk yok. Satılabilecek bilet adedi " + BosKoltukAdediGetir());
            }
        }
        public void BiletIadesi(int tamBiletAdedi, int yarimBiletAdedi)
        {
            if (tamBiletAdedi <= this.ToplamTamBiletAdedi && yarimBiletAdedi <= this.ToplamYarimBiletAdedi)
            {
                this.ToplamTamBiletAdedi -= tamBiletAdedi;
                this.ToplamYarimBiletAdedi -= yarimBiletAdedi;
                //CiroHesapla(); ciro get ile hesaplanıyor. metota gerek kalmadı.
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("İade edilebilecek bilet miktarını aştınız.");
            }
        }
        
        private void CiroHesapla()
        {
          //ciroyu get ile hesapladığımız için bu metota gerek kalmadı.
          //eğer hala metotu kullanmak istiyorsak altdaki kodu yorumdan çıkarıp
          //cirodaki get'i kaldırmak gerekli.

          //this.Ciro = this.ToplamTamBiletAdedi * this.TamBiletFiyati + this.ToplamYarimBiletAdedi * this.YarimBiletFiyati;
        }
        
        public int BosKoltukAdediGetir()
        {
            return this.Kapasite - this.ToplamTamBiletAdedi - this.ToplamYarimBiletAdedi;
        }

    }
}
