﻿using Xamarin.Plugin.Calendar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Plugin.Calendar.Shared.Models;
using Xamarin.Plugin.Calendar.Controls;

namespace SampleApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public bool isBusy = false;
        public MainPageViewModel()
        {
            TappedActionDay = new Action<DateTime>((DateTime date) =>
            {
                System.Diagnostics.Debug.WriteLine("Pressed");
            });

            Culture = CultureInfo.CreateSpecificCulture("en-US");

            // testing all kinds of adding events
            // when initializing collection
            Events = new EventCollection
            {
                [DateTime.Now.AddDays(-3)] = new DayEventCollection()
                {
                    DayEvents = new List<EventModel>(GenerateEvents(10, "Cool")),
                    EventIndicatorColor = Color.Blue
                }
            };

            // with add method
            Events.Add(DateTime.Now.AddDays(-1), new DayEventCollection()
            {
                DayEvents = new List<EventModel>(GenerateEvents(5, "Cool")),
                EventIndicatorColor = Color.Red
            });

            // with indexer
            Events[DateTime.Now] = new DayEventCollection()
            {
                DayEvents = new List<EventModel>(GenerateEvents(2, "Boring")),
                EventIndicatorColor = Color.Purple
            };

            Task.Delay(5000).ContinueWith(_ =>
            {
                // indexer - update later
                Events[DateTime.Now] = new DayEventCollection()
                {
                    DayEvents = new ObservableCollection<EventModel>(GenerateEvents(10, "Cool")),
                    EventIndicatorColor = Color.Brown
                };

                // add later
                Events.Add(DateTime.Now.AddDays(3), new DayEventCollection()
                {
                    DayEvents = new List<EventModel>(GenerateEvents(5, "Cool")),
                    EventIndicatorColor = Color.DarkBlue
                });

                // indexer later
                Events[DateTime.Now.AddDays(10)] = new DayEventCollection()
                {
                    DayEvents = new List<EventModel>(GenerateEvents(10, "Boring")),
                    EventIndicatorColor = Color.Cyan
                };

                // add later
                Events.Add(DateTime.Now.AddDays(15), new DayEventCollection()
                {
                    DayEvents = new List<EventModel>(GenerateEvents(10, "Cool")),
                    EventIndicatorColor = Color.DarkMagenta
                });

                Task.Delay(3000).ContinueWith(t =>
                {
                    // get observable collection later
                    var todayEvents = Events[DateTime.Now].DayEvents as ObservableCollection<EventModel>;

                    // insert/add items to observable collection
                    todayEvents.Insert(0, new EventModel { Name = "Cool event insert", Description = "This is Cool event's description!" });
                    todayEvents.Add(new EventModel { Name = "Cool event add", Description = "This is Cool event's description!" });
                });
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private IEnumerable<EventModel> GenerateEvents(int count, string name)
        {
            return Enumerable.Range(1, count).Select(x => new EventModel
            {
                Name = $"{name} event{x}",
                Description = $"This is {name} event{x}'s description!"
            });
        }

        public Action<DateTime> TappedActionDay { get; set; }

        public EventCollection Events { get; }
        public int Month { get; set; } = DateTime.Now.Month;
        public int Year { get; set; } = DateTime.Now.Year;

        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        private DateTime _minimumDate = new DateTime(2019, 4, 29);
        public DateTime MinimumDate
        {
            get => _minimumDate;
            set => SetProperty(ref _minimumDate, value);
        }

        private DateTime _maximumDate = DateTime.Today.AddMonths(5);
        public DateTime MaximumDate
        {
            get => _maximumDate;
            set => SetProperty(ref _maximumDate, value);
        }

        private CultureInfo _culture = CultureInfo.InvariantCulture;
        public CultureInfo Culture
        {
            get => _culture;
            set => SetProperty(ref _culture, value);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<TData>(ref TData storage, TData value, [CallerMemberName] string propertyName = "")
        {
            if (storage.Equals(value))
                return;

            storage = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
