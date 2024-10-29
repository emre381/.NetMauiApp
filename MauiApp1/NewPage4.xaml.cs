namespace MauiApp1;

public partial class NewPage4 : ContentPage
{
	public NewPage4()
	{
		InitializeComponent();
	}
    private void OnCalculateClicked(object sender, EventArgs e)
    {
        // Kullan�c�dan tarla ve silindir bilgilerini al
        if (double.TryParse(FieldLengthEntry.Text, out double fieldLength) &&
            double.TryParse(FieldWidthEntry.Text, out double fieldWidth) &&
            double.TryParse(CylinderHeightEntry.Text, out double cylinderHeight) &&
            double.TryParse(CylinderDiameterEntry.Text, out double cylinderDiameter))
        {
            // Hesaplama i�lemlerini yap
            Calculate(fieldLength, fieldWidth, cylinderHeight, cylinderDiameter);
        }
        else
        {
            ResultLabel.Text = "L�tfen ge�erli say�lar girin.";
        }
    }

    private void Calculate(double fieldLength, double fieldWidth, double cylinderHeight, double cylinderDiameter)
    {
        // Tarla alan� ve hacmini hesapla
        double fieldArea = fieldLength * fieldWidth;
        double fieldVolume = fieldArea * cylinderHeight; // Tarla hacmi

        // Silindirin alan� ve hacmini hesapla
        double cylinderRadius = cylinderDiameter / 2;
        double cylinderArea = Math.PI * Math.Pow(cylinderRadius, 2); // Silindirin taban alan�
        double cylinderVolume = cylinderArea * cylinderHeight; // Silindirin hacmi

        // Ka� tane silindirin tarlay� kaplayaca��n� hesapla
        double numberOfCylinders = Math.Floor(fieldVolume / cylinderVolume);

        // Sonu�lar� ekrana yaz
        ResultLabel.Text = $"Tarla Alan�: {fieldArea:F2} m�\n" +
                           $"Tarla Hacmi: {fieldVolume:F2} m�\n" +
                           $"Silindirin Taban Alan�: {cylinderArea:F2} m�\n" +
                           $"Silindirin Hacmi: {cylinderVolume:F2} m�\n" +
                           $"Gerekli Silindir Say�s�: {numberOfCylinders}";

        // Silindirin alan ve hacmini g�ster
        CylinderAreaLabel.Text = $"Silindirin Taban Alan�: {cylinderArea:F2} m�";
        CylinderVolumeLabel.Text = $"Silindirin Hacmi: {cylinderVolume:F2} m�";
    }
}