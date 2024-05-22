using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class ShopController
    {

        public static Home Window { get; set; }

        public void Start()
        {
            // Stel de prijslijst in aan de rechter kant.
            ShopManager.SetShopPriceList("Prijzen:\nFoto 10x15: €2.55");

            // Stel de bon in onderaan het scherm
            ShopManager.SetShopReceipt("Eindbedrag\n€");

            // Vul de productlijst met producten
            ShopManager.Products.Add(new KioskProduct() { Name = "Foto 10x15" });
            
            // Update dropdown met producten
            ShopManager.UpdateDropDownProducts();
        }

        // Wordt uitgevoerd wanneer er op de Toevoegen knop is geklikt
        public void AddButtonClick()
        {
            var product = ShopManager.GetSelectedProduct();
            var fotoId = ShopManager.GetFotoId();
            var amount = ShopManager.GetAmount();

            if (product != null && fotoId != null && amount != null)
            {
                double total = amount.Value;
                ShopManager.AddShopReceipt($"\n{amount.Value} x {product.Name}: €{total:F2}");
                double currentTotal = double.Parse(ShopManager.GetShopReceipt().Split('€').Last());
                ShopManager.SetShopReceipt($"Eindbedrag\n€{currentTotal + total:F2}");
            }
            else
            {
                MessageBox.Show("Controleer of alle velden correct zijn ingevuld.");
            }

        }

        // Wordt uitgevoerd wanneer er op de Resetten knop is geklikt
        public void ResetButtonClick()
        {
            ShopManager.SetShopReceipt("Eindbedrag\n€0.00");
        }

        // Wordt uitgevoerd wanneer er op de Save knop is geklikt
        public void SaveButtonClick()
        {
            //string receipt = ShopManager.GetShopReceipt();
            //string filePath = "receipt.txt";
            //File.WriteAllText(filePath, receipt);
            //MessageBox.Show($"Bon opgeslagen naar {filePath}");
        }

    }
}
