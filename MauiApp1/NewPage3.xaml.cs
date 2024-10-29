namespace MauiApp1;

public partial class NewPage3 : ContentPage
{
	public NewPage3()
	{
        InitializeComponent();
	}
    private void OnCalculateClicked(object sender, EventArgs e)
    {
        // Kullan�c�dan h�z ve mesafe de�erlerini al
        if (double.TryParse(SpeedEntry.Text, out double speed) &&
            double.TryParse(DistanceEntry.Text, out double distance))
        {
            // S�reyi hesapla
            CalculateTime(speed, distance);
        }
        else
        {
            ResultLabel.Text = "L�tfen ge�erli say�lar girin.";
        }
    }

    private void CalculateTime(double speed, double distance)
    {
        if (speed <= 0)
        {
            ResultLabel.Text = "Ortalama h�z s�f�rdan b�y�k olmal�d�r.";
            return;
        }

        // Zaman� hesapla: zaman = mesafe / h�z
        double time = distance / speed; // zaman saat cinsindendir
                                        // S�reyi saat ve dakika cinsine d�n��t�r
        int hours = (int)time;
        int minutes = (int)((time - hours) * 60);

        ResultLabel.Text = $"Zaman: {hours} saat, {minutes} dakika";
    }
}