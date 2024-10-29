namespace MauiApp1;

public partial class NewPage3 : ContentPage
{
	public NewPage3()
	{
        InitializeComponent();
	}
    private void OnCalculateClicked(object sender, EventArgs e)
    {
        // Kullanýcýdan hýz ve mesafe deðerlerini al
        if (double.TryParse(SpeedEntry.Text, out double speed) &&
            double.TryParse(DistanceEntry.Text, out double distance))
        {
            // Süreyi hesapla
            CalculateTime(speed, distance);
        }
        else
        {
            ResultLabel.Text = "Lütfen geçerli sayýlar girin.";
        }
    }

    private void CalculateTime(double speed, double distance)
    {
        if (speed <= 0)
        {
            ResultLabel.Text = "Ortalama hýz sýfýrdan büyük olmalýdýr.";
            return;
        }

        // Zamaný hesapla: zaman = mesafe / hýz
        double time = distance / speed; // zaman saat cinsindendir
                                        // Süreyi saat ve dakika cinsine dönüþtür
        int hours = (int)time;
        int minutes = (int)((time - hours) * 60);

        ResultLabel.Text = $"Zaman: {hours} saat, {minutes} dakika";
    }
}