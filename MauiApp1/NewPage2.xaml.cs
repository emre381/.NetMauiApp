using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;


namespace MauiApp1;

public partial class NewPage2 : ContentPage
{

    public NewPage2()
	{

        InitializeComponent();
    }
    private void OnCalculateClicked(object sender, EventArgs e)
    {
        // Kullanýcýdan a, b ve c deðerlerini al
        if (double.TryParse(AValue.Text, out double a) &&
            double.TryParse(BValue.Text, out double b) &&
            double.TryParse(CValue.Text, out double c))
        {
            // Denklemin köklerini hesapla
            CalculateRoots(a, b, c);
        }
        else
        {
            ResultLabel.Text = "Lütfen geçerli sayýlar girin.";
        }
    }

    private void CalculateRoots(double a, double b, double c)
    {
        // Diskriminantý hesapla
        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            // Ýki farklý gerçek kök
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            ResultLabel.Text = $"Kökler: x1 = {root1}, x2 = {root2}";
        }
        else if (discriminant == 0)
        {
            // Tek bir kök
            double root = -b / (2 * a);
            ResultLabel.Text = $"Tek kök: x = {root}";
        }
        else
        {
            // Gerçek kök yok
            ResultLabel.Text = "Gerçek kök yok.";
        }
    }
}