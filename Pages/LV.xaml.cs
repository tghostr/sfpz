using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для LV.xaml
    /// </summary>
    public partial class LV : Page
    {
        public LV()
        {
            InitializeComponent();
            Update();
            //Server = cfif31.ru; Port = 3306; User ID = ISPr23-35_TazetdinovRR;  Password = ISPr23-35_TazetdinovRR; Database = ISPr23-35_TazetdinovRR_11v; Character Set = utf8
            cbSort.Items.Add("По возрастанию");
            cbSort.Items.Add("По убыванию");
            cbSort.SelectedIndex = 0;

            List<PhoneBrand> brands = Ispr2335TazetdinovRr11vContext.init().PhoneBrands.ToList();
            brands.Insert(0, new PhoneBrand { PhoneBrandName = "Все бренды" });
            cbFiltr.ItemsSource = brands;
            cbFiltr.SelectedIndex = 0;
        }
        private void Update()
        {
            IEnumerable<Phone> phones = Ispr2335TazetdinovRr11vContext.init().Phones.Include(p => p.PhoneBrand).Where(p => p.PhoneModel.Contains(tbSearch.Text));


            switch (cbSort.SelectedIndex)
            {
                case 0:
                    phones = phones.OrderBy(p => p.PhonePrice);
                    break;
                case 1:
                    phones = phones.OrderByDescending(p => p.PhonePrice);
                    break;
            }

            if (cbFiltr.SelectedIndex > 0)
                phones = phones.Where(p => p.PhoneBrandId == (cbFiltr.SelectedItem as PhoneBrand).PhoneBrandId);

            lvPhones.ItemsSource = Ispr2335TazetdinovRr11vContext.init().Phones.ToList();

        }

        private void tbSearchChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void cbSortChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void cbFiltrChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void btLvClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DGV());
        }
    }
}
