//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xamarin.Forms;

//namespace VaccineCalendar.Behaviors
//{
//    public class DateToAgeBehavior: Behavior<DatePicker>
//    {
//        Entry _entry;

//        public DateToAgeBehavior(Entry entry): base()
//        {
//            _entry = entry;
//        }

//        protected override void OnAttachedTo(DatePicker bindable)
//        {
//            base.OnAttachedTo(bindable);
//            bindable.DateSelected += DateSelected_Handler;
//        }

//        private void DateSelected_Handler(object sender, DateChangedEventArgs e)
//        {

//            DatePicker datePicker = sender as DatePicker;
//            if (datePicker == null)
//                return;

//            if (_entry != null)
//                _entry.Text = Shared.Calendar.IdadeTexto(datePicker.Date);

//        }

//        protected override void OnDetachingFrom(DatePicker bindable)
//        {
//            base.OnDetachingFrom(bindable);
//            bindable.DateSelected -= DateSelected_Handler;
//        }


//    }
//}
