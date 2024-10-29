namespace MauiApp1;

public partial class NewPage4 : ContentPage
{
	public NewPage4()
	{
		InitializeComponent();
	}
    private void OnCalculateClicked(object sender, EventArgs e)
    {
        // Kullanýcýdan tarla ve silindir bilgilerini al
        if (double.TryParse(FieldLengthEntry.Text, out double fieldLength) &&
            double.TryParse(FieldWidthEntry.Text, out double fieldWidth) &&
            double.TryParse(CylinderHeightEntry.Text, out double cylinderHeight) &&
            double.TryParse(CylinderDiameterEntry.Text, out double cylinderDiameter))
        {
            // Hesaplama iþlemlerini yap
            Calculate(fieldLength, fieldWidth, cylinderHeight, cylinderDiameter);
        }
        else
        {
            ResultLabel.Text = "Lütfen geçerli sayýlar girin.";
        }
    }

    private void Calculate(double fieldLength, double fieldWidth, double cylinderHeight, double cylinderDiameter)
    {
        // Tarla alaný ve hacmini hesapla
        double fieldArea = fieldLength * fieldWidth;
        double fieldVolume = fieldArea * cylinderHeight; // Tarla hacmi

        // Silindirin alaný ve hacmini hesapla
        double cylinderRadius = cylinderDiameter / 2;
        double cylinderArea = Math.PI * Math.Pow(cylinderRadius, 2); // Silindirin taban alaný
        double cylinderVolume = cylinderArea * cylinderHeight; // Silindirin hacmi

        // Kaç tane silindirin tarlayý kaplayacaðýný hesapla
        double numberOfCylinders = Math.Floor(fieldVolume / cylinderVolume);

        // Sonuçlarý ekrana yaz
        ResultLabel.Text = $"Tarla Alaný: {fieldArea:F2} m²\n" +
                           $"Tarla Hacmi: {fieldVolume:F2} m³\n" +
                           $"Silindirin Taban Alaný: {cylinderArea:F2} m²\n" +
                           $"Silindirin Hacmi: {cylinderVolume:F2} m³\n" +
                           $"Gerekli Silindir Sayýsý: {numberOfCylinders}";

        // Silindirin alan ve hacmini göster
        CylinderAreaLabel.Text = $"Silindirin Taban Alaný: {cylinderArea:F2} m²";
        CylinderVolumeLabel.Text = $"Silindirin Hacmi: {cylinderVolume:F2} m³";
    }
}