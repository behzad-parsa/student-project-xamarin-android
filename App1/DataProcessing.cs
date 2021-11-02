using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    class DataProcessing
    {
        //private static List<Contact> _allContact;

        //public static List<Contact> menuList = new List<Contact>();


        //public DataProcessing()
        //{
        //    _allContact = new List<Contact>();
        //}


        //public static void AddToAllContact(string name , string post , string dTel , string extTel , string email)
        //{
        //    _allContact.Add()
        //}

        public static List<Contact> allContact = new List<Contact>();
        public static List<TreeNode<string>> menuList = new List<TreeNode<string>>();
        public static List<Category> lstCategory = new List<Category>();
        public static List<Product> lstProduct = new List<Product>();
        public static bool addDataFlag = false;
        public static bool addDataMarketFlag = false;

        public static void BeginAddProductList()
        {
            addDataMarketFlag = true;
            AddCategory();

            lstProduct.Add(new Product("OS Book", "30000", "Writed By : ... \nPublished By : .. ", new DateTime(2015, 05, 6 , 15 , 40 , 23), new User("Behzad", "Computer", "09111794629", "Behzas@yahoo.com"), "Book"));
            lstProduct.Add(new Product("Hamkhoneh", "2000520", "Foooori", new DateTime(2017, 01, 1), new User("Behzad", "Computer", "123546", "Behzas@yahoo.com"), "Home"));
            lstProduct.Add(new Product("Asus N56J", "2540000", "Foooori", new DateTime(2015, 05, 6), new User("Behzad", "Computer", "123546", "Behzas@yahoo.com"), "Computer|Laptop"));
            lstProduct.Add(new Product("Iphone 7", "2500000", "Foooori", new DateTime(2015, 05, 6), new User("Behzad", "Computer", "123546", "Behzas@yahoo.com"), "CellPhone|Tablet"));
            lstProduct.Add(new Product("Jozve Signal", "15000", "Foooori", new DateTime(2015, 05, 6), new User("Behzad", "Computer", "123546", "Behzas@yahoo.com"), "Book"));
            lstProduct.Add(new Product("Ghormeh Sabzi", "1200", "Baray Rooz Yekshanbe", new DateTime(2018, 4, 6 , 10 , 12 , 54), new User("Ali", "Computer", "09113740540", "Behzas@yahoo.com"), "Food"));

        }
        private static void AddCategory()
        {


            lstCategory.Add(new Category("All", Resource.Drawable.call));
            lstCategory.Add(new Category("Food", Resource.Drawable.cfood));
            lstCategory.Add(new Category("Computer|Laptop", Resource.Drawable.claptop));
            lstCategory.Add(new Category("CellPhone|Tablet", Resource.Drawable.cphone));
            lstCategory.Add(new Category("Project", Resource.Drawable.cproject));
            lstCategory.Add(new Category("Book", Resource.Drawable.cbook));
            lstCategory.Add(new Category("Home", Resource.Drawable.chome));



        }
        private static void BeginAddMenu()
        {


            //  menuList.Add(new TreeNode<string>("Library"));
            //  menuList.Add(new TreeNode<string>("Department Of Research"));
            //  menuList.Add(new TreeNode<string>("Information Technology Center"));

            ////  menuList.Find(r => r.Data == "Department Of Research").AddChild("Information Technology Center");
            //  //menuList.Find(r => r.Data == "Department Of Research").AddChild("Library");
            //  AddToTree(menuList.Find(r => r.Data == "Department Of Research"), menuList.Find(r => r.Data == "Information Technology Center"));
            //  AddToTree(menuList.Find(r => r.Data == "Department Of Research"), menuList.Find(r => r.Data == "Library"));


            //  menuList.Add(new TreeNode<string>("A"));
            //  menuList.Add(new TreeNode<string>("B"));
            //  menuList.Add(new TreeNode<string>("C"));

            //  AddToTree(menuList.Find(r => r.Data == "A"), menuList.Find(r => r.Data == "B"));
            //  AddToTree(menuList.Find(r => r.Data == "A"), menuList.Find(r => r.Data == "C"));


            //menuList.Add(new TreeNode<string>("All Contacts"));

            menuList.Add(new TreeNode<string>("Ketabkhane"));
            menuList.Add(new TreeNode<string>("Moavenat Pazhohesh Va Fanavari"));
            menuList.Add(new TreeNode<string>("Markaz Fanavari Etelaat Va Khadamat Rayane"));

            //  menuList.Find(r => r.Data == "Department Of Research").AddChild("Information Technology Center");
            //menuList.Find(r => r.Data == "Department Of Research").AddChild("Library");
            AddToTree(menuList.Find(r => r.Data == "Moavenat Pazhohesh Va Fanavari"), menuList.Find(r => r.Data == "Markaz Fanavari Etelaat Va Khadamat Rayane"));
            AddToTree(menuList.Find(r => r.Data == "Moavenat Pazhohesh Va Fanavari"), menuList.Find(r => r.Data == "Ketabkhane"));


            menuList.Add(new TreeNode<string>("Daneshkade Bargh Va Computer"));
            menuList.Add(new TreeNode<string>("Asatid Bargh Va Computer"));
            //menuList.Add(new TreeNode<string>("C"));

            AddToTree(menuList.Find(r => r.Data == "Daneshkade Bargh Va Computer"), menuList.Find(r => r.Data == "Asatid Bargh Va Computer"));
            //AddToTree(menuList.Find(r => r.Data == "Daneshkade Bargh Va Computer"), menuList.Find(r => r.Data == "C"));







            // menuList.Find(r => r.Data == "Department Of Research").AddChild("Information Technology Center");

        }

        public static void BeginAddData()
        {
            // var obj = new TreeNode<string>("Library");
            addDataFlag = true;

            BeginAddMenu();

            //AddToTree(menuList.Find(r => r.Data == "Department Of Research"),  menuList.Find(r => r.Data == "Library"));

            //allContact.Add(new Contact("Zahaee", "Boss", "32366538", "1565", "Asabi@Yahoo.com", menuList.Find(r=>r.Data == "Library")));
            //allContact.Add(new Contact("Vailg", "MOsirGoroh", "213215", "1565", "Asabi@Yahoo.com" , menuList.Find(r => r.Data == "Library")));
            //allContact.Add(new Contact("Mansori", "Ostad", "21551315", "14545", "Mansor@Yahoo.com" , menuList.Find(r => r.Data == "Library")));
            //allContact.Add(new Contact("Vahedi", "server", "21551315", "14545", "Mansor@Yahoo.com" , menuList.Find(r => r.Data == "Library")));
            //allContact.Add(new Contact("mahmosi", "marjaz", "21551315", "14545", "Mansor@Yahoo.com" , menuList.Find(r => r.Data == "Library")));
            //allContact.Add(new Contact("payab", "Amoozesh", "21551315", "14545", "Mansor@Yahoo.com" , menuList.Find(r => r.Data == "Library")));

            //allContact.Add(new Contact("Mansori", "MOsirGoroh", "213215", "1565", "Man@Yahoo.com", menuList.Find(r => r.Data == "Information Technology Center")));
            //allContact.Add(new Contact("Vailg", "MOsirGoroh", "213215", "1565", "Asabi@Yahoo.com", menuList.Find(r => r.Data == "Information Technology Center")));
            //allContact.Add(new Contact("Mansori", "Ostad", "21551315", "14545", "Mansor@Yahoo.com", menuList.Find(r => r.Data == "Information Technology Center")));
            //allContact.Add(new Contact("Vahedi", "server", "21551315", "14545", "Mansor@Yahoo.com", menuList.Find(r => r.Data == "Information Technology Center")));
            //allContact.Add(new Contact("mahmosi", "marjaz", "21551315", "14545", "Mansor@Yahoo.com", menuList.Find(r => r.Data == "Information Technology Center")));
            //allContact.Add(new Contact("payab", "Amoozesh", "21551315", "14545", "Mansor@Yahoo.com", menuList.Find(r => r.Data == "Information Technology Center")));


            //allContact.Add(new Contact("Mansori", "MOsirGoroh", "213215", "1565", "Man@Yahoo.com", menuList.Find(r => r.Data == "Department Of Research")));
            //allContact.Add(new Contact("Vailg", "MOsirGoroh", "213215", "1565", "Asabi@Yahoo.com", menuList.Find(r => r.Data == "Department Of Research")));
            //allContact.Add(new Contact("Mansori", "Ostad", "21551315", "14545", "Mansor@Yahoo.com", menuList.Find(r => r.Data == "Department Of Research")));
            //allContact.Add(new Contact("Vahedi", "server", "21551315", "14545", "Mansor@Yahoo.com", menuList.Find(r => r.Data == "Department Of Research")));
            //allContact.Add(new Contact("mahmosi", "marjaz", "21551315", "14545", "Mansor@Yahoo.com", menuList.Find(r => r.Data == "Department Of Research")));
            //allContact.Add(new Contact("payab", "Amoozesh", "21551315", "14545", "Mansor@Yahoo.com", menuList.Find(r => r.Data == "Department Of Research")));


            //---------------------------------------------------------------------------------------------------------------------------------------------------
            //allContact.Add(new Contact("A1", "Accessory of Technology & Research", null, "1150-1160-1152-1158-1159-1160-1162", "zahaee@Yahoo.com", "Department Of Research"));
            //allContact.Add(new Contact("A2", "Accessory of Technology & Research", "32364905-32366538-32352456-32366999-32358569", "1150-1160-1152-1158-1159-1160-1162", null, "Department Of Research"));



            //allContact.Add(new Contact("Taghizade", "Accessory of Technology & Research", "null", "1152", "zahaee@Yahoo.com" , "Department Of Research"));

            //allContact.Add(new Contact("Ahmadi", "Accessory Office & Fax", "32369786", "1150-1160-1152-1158-1159", "zahaee@Yahoo.com", "Department Of Research"));

            //allContact.Add(new Contact("Dehestani", "Research Manager", "null", "1153", "zahaee@Yahoo.com", "Department Of Research"));


            //allContact.Add(new Contact("Nazari", "Magazine Publishing Office", "32312271", "1157", "zahaee@Yahoo.com", "Department Of Research"));


            //allContact.Add(new Contact("Shafeghat", "JNSE Magazine", "32364902", "1156", "zahaee@Yahoo.com", "Department Of Research"));


            //allContact.Add(new Contact("Shafeghat", "Industry Communication Manager", "null", "1154", "zahaee@Yahoo.com", "Department Of Research"));

            //allContact.Add(new Contact("Bagheri", "Industry Communication Office", "null", "1155", "zahaee@Yahoo.com", "Department Of Research"));

            //allContact.Add(new Contact("Gorji", "Research", "null", "1165", "zahaee@Yahoo.com", "Department Of Research"));

            //allContact.Add(new Contact("Nopour", "Research Pantry", "null", "1155", "zahaee@Yahoo.com", "Department Of Research"));

            //allContact.Add(new Contact("Ganji", "Boss", "null", "1175", "zahaee@Yahoo.com", "Information Technology Center"));

            //allContact.Add(new Contact("Mahmoudi", "Office & Fax", "32364904", "1171", "zahaee@Yahoo.com", "Information Technology Center"));

            //allContact.Add(new Contact("Vahedi", "Network Manager", "null", "1177", "zahaee@Yahoo.com", "Information Technology Center"));

            //allContact.Add(new Contact("Vahedi", "Internet Server", "32364905", "1174", "zahaee@Yahoo.com", "Information Technology Center"));

            //allContact.Add(new Contact("Firoozmandi", "PHD Site", "null", "1178", "zahaee@Yahoo.com", "Information Technology Center"));

            //allContact.Add(new Contact("Dehzad", "Repair Room", "null", "1179", "zahaee@Yahoo.com", "Information Technology Center"));

            //allContact.Add(new Contact("Vahedi & Firoozmandi", "Master server", "1174", "1174", "zahaee@Yahoo.com", "Information Technology Center"));

            //allContact.Add(new Contact("Hedayati", "Repairs", "1172", "1173", "zahaee@Yahoo.com", "Information Technology Center"));

            //allContact.Add(new Contact("Baleghi", "MA", "null", "1170", "zahaee@Yahoo.com", "Information Technology Center"));

            //allContact.Add(new Contact("Ostadian", "Pantry", "null", "1174", "zahaee@Yahoo.com", "Information Technology Center"));

            //allContact.Add(new Contact("Zahaee", "Boss", "32366538", "1180", "zahaee@Yahoo.com", "Library"));

            //allContact.Add(new Contact("Kiani", "Office", "null", "1181", "zahaee@Yahoo.com", "Library"));

            //allContact.Add(new Contact("Vasegh Nezhad", "Reference", "null", "1187", "zahaee@Yahoo.com", "Library"));

            //allContact.Add(new Contact("Bakhshi", "Administrative", "null", "1182", "zahaee@Yahoo.com", "Library"));

            //allContact.Add(new Contact("Shirvani & Mirgeti & Ahmad Tabar", "Lending", "null", "1188", "zahaee@Yahoo.com", "Library"));

            //allContact.Add(new Contact("Hossein Zade", "Pantry", "null", "1183", "zahaee@Yahoo.com", "Library"));

            //allContact.Add(new Contact("Ghorban Nia", "Religious Group", "32310465", "1900", "zahaee@Yahoo.com", "Department Of Research"));
            //allContact.Add(new Contact("Pousti", "Roshd Center Office & Fax", "32369786", "1130,1131", "zahaee@Yahoo.com", "Department Of Research"));
            //allContact.Add(new Contact("Abbasi", "Rosh Center Manager", "null", "1132", "zahaee@Yahoo.com", "Department Of Research"));


            allContact.Add(new Contact("Zahaee", "Raees", "32366538", "1180", "zahaee@Yahoo.com", "Ketabkhane"));

            allContact.Add(new Contact("Kiani", "Daftar", null, "1181", null, "Ketabkhane"));

            allContact.Add(new Contact("Vasegh nezhad ", "Marja", null, "1187", null, "Ketabkhane"));

            allContact.Add(new Contact("naderi", "Majalat", null, "1186", null, "Ketabkhane"));

            allContact.Add(new Contact("Bakhshi", "Edari", null, "1182", null, "Ketabkhane"));

            allContact.Add(new Contact("Shirvani", "Amanat", null, "1188", null, "Ketabkhane"));

            allContact.Add(new Contact("Mirgati", "Amanat", null, "1188", null, "Ketabkhane"));

            allContact.Add(new Contact("Ahmad Tabar", "Amanat", null, "1188", null, "Ketabkhane"));

            allContact.Add(new Contact("Hossein Zade", "Abadarkhane", null, "1183", null, "Ketabkhane"));

            allContact.Add(new Contact("Ghorban Nia", "Maaref", "32310456", "11900", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Poosti", "Daftar Markaz Roshd", " 32349786", "1130", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Poosti", "Fax", " 32349786", "1131", null, "Moavenat Pazhohesh Va Fanavari"));
            allContact.Add(new Contact("Abbasi", "Modir Markaz Roshd", null, "1132", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Taghi Zadeh", "Moavenat Pazhohesh Va Fanavari", null, "1152", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Ahmadi", "Daftar Moavenat", "32369786", "1150", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Ahmadi", "Fax", "32369786", "1160", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Dehestani", "Modir Pazhoheshi", null, "1153", null,"Moavenat Pazhohesh Va Fanavari"));
            

            allContact.Add(new Contact("Nazari", "Daftar Entesharat(Majale)", "32312271", "1157", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("SHafaghat", "Majale JSNE", "32364902", "1156", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Shafaghat", "Modir Ertebat BA Sanat", null, "1154", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Bagheri", "Daftar Ertebat BA Sanat", null, "1155", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Gorji", "Pahoheshi", null, "1165", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Nopur", "Abdarhane Pazhoheshi", null, "1161", null, "Moavenat Pazhohesh Va Fanavari"));

            allContact.Add(new Contact("Ganji", "Raees", null, "1175", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));


            allContact.Add(new Contact("Mahmoudi", "Daftar Va Fax", "32364904", "1171", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));


            allContact.Add(new Contact("Vahedi", "Modir Shabake", null, "1177", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));


            allContact.Add(new Contact("Vahedi", "Server Internet", "32364905", "1175", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));

            allContact.Add(new Contact("Firouzmandi", "Site Doctora", null, "1178", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));


            allContact.Add(new Contact("Dehzad", "Otagh Tamirat", null, "1179", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));


            allContact.Add(new Contact("Vahedi", "Server Karshenasi", "1174", "1172", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));


            allContact.Add(new Contact("Firouzmandi", "Server Karshenasi", "1174", "1172", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));


            allContact.Add(new Contact("Hedayati", "Tamirat", "1172", "1173", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));


            allContact.Add(new Contact("Baleghi", "Karshenasi Arshad", null, "1170", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));


            allContact.Add(new Contact("Ostadiyan", "Abdarkhane", null, "1174", null, "Markaz Fanavari Etelaat Va Khadamat Rayane"));


            allContact.Add(new Contact("Gholamian", "Raees Daneshkade", null, "1403", null, "Daneshkade Bargh Va Computer"));

            allContact.Add(new Contact("Sakhaei", "Moaven Amouzeshi", null, "1411", null, "Daneshkade Bargh Va Computer"));

            allContact.Add(new Contact("Goli", "Daftar Va Fax", "32339214-32310977", "1400-1401-1402", null, "Daneshkade Bargh Va Computer"));

            allContact.Add(new Contact("Payab", "Amouzesh", null, "1405", null, "Daneshkade Bargh Va Computer"));

            allContact.Add(new Contact("Sakhaei", "Ostad", null, "1411", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Jazayeri", "Ostad", null, "1436", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Hoseini Andargoli", "Ostad", null, "1430", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Jafari", "Ostad", null, "1430", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Barforushi", "Ostad", null, "1441", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Ezoji", "Ostad", null, "1435", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Adabi", "Ostad", null, "1435", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Al Ahmad", "Ostad", null, "1434", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Gol", "Ostad", null, "1470", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Karami", "Ostad", null, "1431", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Hoseini", "Ostad", null, "1425", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Mansouri", "Ostad", null, "1421", null, "Asatid Bargh Va Computer"));


            allContact.Add(new Contact("Vali Nataj", "Ostad", null, "1421", null, "Asatid Bargh Va Computer"));


            ///TEST
            allContact.Add(new Contact("Behzad Pesarakluo", "Student", "09111794629-09210479224-09113740540", "1421", null, "Asatid Bargh Va Computer"));


        }




        private static void AddToTree (TreeNode<string> parent , TreeNode<string> child)
        {

            parent.AddChild(child);

        }

        ///filter menu
        ///
        public static List<Contact> FilterContactList(string keyword)
        {

            var filterList = allContact.FindAll(r => r.ParentMenu.Data.Equals(keyword));
            return filterList ;
        }

        public static List<Product> FilterProductList(string keyword)
        {

            var filterList = lstProduct.FindAll(r => r.Category.Equals(keyword));
            return filterList;
        }


        //public static List<ExpandedMenuModel> NavigationProcess()
        //{
        //    ExpandedMenuModel h = new ExpandedMenuModel();
        //    List<ExpandedMenuModel> hlst = new List<ExpandedMenuModel>();

        //    var listb = menuList.FindAll(r => r.IsRoot() == true);


        //    hlst.Add() 


        //    return;
        //}
    }
}