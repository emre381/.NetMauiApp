using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Maui.Controls;
namespace MauiApp1;

public partial class NewPage1 : ContentPage
{
    private Dictionary<string, double> dovizKurlari = new Dictionary<string, double>();
    public NewPage1()
	{
        InitializeComponent();
        DovizKurlariYukle();
        HaberleriYukle();
    }

    // RSS Kayna��ndan D�viz Kurlar�n� Y�kleme
    private async void DovizKurlariYukle()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string rssUrl = "https://www.tcmb.gov.tr/kurlar/today.xml"; // TCMB d�viz kurlar� XML URL'si
                var response = await client.GetStringAsync(rssUrl);

                // XML ayr��t�rma
                XDocument xmlDoc = XDocument.Parse(response);
                foreach (var item in xmlDoc.Descendants("Currency"))
                {
                    string currencyCode = item.Attribute("Kod").Value;
                    double rate = double.Parse(item.Element("ForexBuying").Value.Replace(",", "."));
                    dovizKurlari[currencyCode] = rate;
                }

                // Picker i�in d�viz kodlar�n� ekle
                KaynakDovizPicker.ItemsSource = new List<string>(dovizKurlari.Keys);
                HedefDovizPicker.ItemsSource = new List<string>(dovizKurlari.Keys);
            }
        }
        catch (Exception ex)
        {
            SonucLabel.Text = $"D�viz kurlar� y�klenemedi: {ex.Message}";
        }
    }

    // Investing.com RSS Haberlerini Y�kleme
    private async void HaberleriYukle()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string rssUrl = "https://tr.investing.com/rss/news_1.rss"; // Investing.com RSS haber kayna��
                var response = await client.GetStringAsync(rssUrl);

                // XML ayr��t�rma
                XDocument xmlDoc = XDocument.Parse(response);
                List<string> haberler = new List<string>();

                foreach (var item in xmlDoc.Descendants("item"))
                {
                    string title = item.Element("title").Value;
                    haberler.Add(title);
                }

                // ListView'e haber ba�l�klar�n� ekle
                HaberlerListView.ItemsSource = haberler;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", $"Haberler y�klenemedi: {ex.Message}", "Tamam");
        }
    }

    // �evirme ��lemi
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (double.TryParse(MiktarEntry.Text, out double miktar) &&
            KaynakDovizPicker.SelectedItem != null &&
            HedefDovizPicker.SelectedItem != null)
        {
            string kaynakDoviz = KaynakDovizPicker.SelectedItem.ToString();
            string hedefDoviz = HedefDovizPicker.SelectedItem.ToString();

            if (dovizKurlari.ContainsKey(kaynakDoviz) && dovizKurlari.ContainsKey(hedefDoviz))
            {
                double kaynakKur = dovizKurlari[kaynakDoviz];
                double hedefKur = dovizKurlari[hedefDoviz];

                // D�viz �evirme
                double sonuc = (miktar * kaynakKur) / hedefKur;
                SonucLabel.Text = $"{miktar} {kaynakDoviz} = {sonuc:F2} {hedefDoviz}";
            }
            else
            {
                SonucLabel.Text = "D�viz kurlar� bulunamad�.";
            }
        }
        else
        {
            SonucLabel.Text = "L�tfen t�m alanlar� do�ru doldurun.";
        }
    }
}