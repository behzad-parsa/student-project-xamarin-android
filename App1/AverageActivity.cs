using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V4.View;
using Android.Support.V7.App;
//using Android.Support.V7.wiq
using Android.Support.V7.Widget;
using SearchView = Android.Widget.SearchView;
using Android.Widget;
using Newtonsoft.Json;
using Android.Support.V7.AppCompat;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
namespace App1
{
    [Activity(Label = "AverageActivity" , Theme = "@style/MyTheme")]
    public class AverageActivity : AppCompatActivity
    {
        public static bool isThemeChange = false;
        private Button btnAdd;
        private EditText editGrade;
        private EditText editUnit;
        private EditText editName;
        private ListView lstView;
        private LessonAdapter _lessonAdpater;
        private List<Lesson> lstLesson = new List<Lesson>();
        private LinearLayout lnAvg;
        private TextView txtAverage;
        private Button btnCalculate;
        private Button btnClear;


        //private ImageButton imgBtnClose;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            UITheme.changeTheme(this, SettingActivity.theme);
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Average);

            var toolbar = FindViewById<Toolbar>(Resource.Id.averageToolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayShowTitleEnabled(false);




            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            editGrade = FindViewById<EditText>(Resource.Id.editGrade);
            editUnit = FindViewById<EditText>(Resource.Id.editUnit);
            editName = FindViewById<EditText>(Resource.Id.editName);
            lstView = FindViewById<ListView>(Resource.Id.lstViewAve);
            txtAverage = FindViewById<TextView>(Resource.Id.txtShowAv);
            lnAvg = FindViewById<LinearLayout>(Resource.Id.linearLayoutAve);
            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            lnAvg.Visibility = ViewStates.Gone;
            btnClear = FindViewById<Button>(Resource.Id.btnClear);


            //imgBtnClose = FindViewById<ImageButton>(Resource.Id.imgDelete);












            toolbar.NavigationClick += Toolbar_NavigationClick;
            btnAdd.Click += BtnAdd_Click;
            btnCalculate.Click += BtnCalculate_Click;
            btnClear.Click += BtnClear_Click;


            //imgBtnClose.Click += ImgBtnClose_Click;
        }

        //private void ImgBtnClose_Click(object sender, EventArgs e)
        //{
        //    _lessonAdpater.GetItemAtPosition(e.po)
        //}

        private void BtnClear_Click(object sender, EventArgs e)
        {
            lnAvg.Visibility = ViewStates.Gone;
            lstLesson.Clear();
            _lessonAdpater = new LessonAdapter(this, lstLesson);
            lstView.Adapter = _lessonAdpater;
            ///editGrade.SetText('' , 0 , );

        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            lnAvg.Visibility = ViewStates.Visible;
            double sumGrade = 0;
            int sumUnits = 0;
            double avg;
            foreach (var item in lstLesson)
            {
                sumGrade = sumGrade + (item.Unit * item.Grade);
                sumUnits = sumUnits + item.Unit;




            }
            avg = (double)sumGrade / sumUnits;
            txtAverage.Text = avg.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lstLesson.Add(new Lesson(editName.Text, int.Parse(editUnit.Text), double.Parse(editGrade.Text)));
            //editGrade.Hint = "grade";
            //editName.Hint = "name";
            //editUnit.Hint = "hint";


            _lessonAdpater = new LessonAdapter(this, lstLesson);
            lstView.Adapter = _lessonAdpater;
        }


        protected override void OnResume()
        {
            base.OnResume();
            if (isThemeChange)
            {
                isThemeChange = false;
                Recreate();

            }
        }

        private void Toolbar_NavigationClick(object sender, Toolbar.NavigationClickEventArgs e)
        {
            this.Finish();
        }
    }





    
}