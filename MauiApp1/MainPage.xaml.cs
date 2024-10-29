namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            // Girdileri al ve sayıya çevir
            if (double.TryParse(DirencEntry.Text, out double direnc) &&
                double.TryParse(AkimEntry.Text, out double akim) &&
                double.TryParse(ZamanEntry.Text, out double zamanDakika))
            {
                // Güç hesapla
                double guc = HesaplaGuc(akim, direnc);

                // Enerji hesapla (kWh cinsinden)
                double enerjiKwh = HesaplaEnerjiKwh(guc, zamanDakika);

                // Maliyet hesapla (1 kWh başına maliyet olarak örneğin 1.5 TL alındı)
                double birimFiyat = 1.5;
                double maliyet = HesaplaMaliyet(enerjiKwh, birimFiyat);

                // Sonuçları göster
                SonucLabel.Text = $"Güç: {guc:F2} W\n" +
                                  $"Enerji Tüketimi: {enerjiKwh:F4} kWh\n" +
                                  $"Maliyet: {maliyet:F2} TL";
            }
            else
            {
                // Hatalı giriş durumunda uyarı mesajı göster
                SonucLabel.Text = "Lütfen tüm değerleri doğru formatta girin.";
            }
        }
        // Güç Hesaplama (Watt)
        private double HesaplaGuc(double akim, double direnc)
        {
            return Math.Pow(akim, 2) * direnc;
        }

        // Enerji Hesaplama (kWh)
        private double HesaplaEnerjiKwh(double guc, double zamanDakika)
        {
            return (guc * zamanDakika) / (60 * 1000);
        }

        // Maliyet Hesaplama (TL)
        private double HesaplaMaliyet(double enerjiKwh, double birimFiyat)
        {
            return enerjiKwh * birimFiyat;
        }
    }

}
