﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Plugin.Calendar.Models;

namespace Xamarin.Plugin.Calendar.Controls
{
    /// <summary>
    /// Calendar plugin for Xamarin.Forms
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calendar : ContentView
    {
        #region Bindable properties

        public static readonly BindableProperty ShowMonthPickerProperty =
          BindableProperty.Create(nameof(ShowMonthPicker), typeof(bool), typeof(Calendar), true);

        public bool ShowMonthPicker
        {
            get => (bool) GetValue(ShowMonthPickerProperty);
            set => SetValue(ShowMonthPickerProperty, value);
        }

        public static readonly BindableProperty ShowYearPickerProperty =
          BindableProperty.Create(nameof(ShowYearPicker), typeof(bool), typeof(Calendar), true);

        public bool ShowYearPicker
        {
            get => (bool) GetValue(ShowYearPickerProperty);
            set => SetValue(ShowYearPickerProperty, value);
        }

        public static readonly BindableProperty MonthProperty =
          BindableProperty.Create(nameof(Month), typeof(int), typeof(Calendar), DateTime.Now.Month, BindingMode.TwoWay);

        public int Month
        {
            get => (int) GetValue(MonthProperty);
            set => SetValue(MonthProperty, value);
        }

        public static readonly BindableProperty YearProperty =
          BindableProperty.Create(nameof(Year), typeof(int), typeof(Calendar), DateTime.Now.Year, BindingMode.TwoWay);

        public int Year
        {
            get => (int) GetValue(YearProperty);
            set => SetValue(YearProperty, value);
        }

        public static readonly BindableProperty SelectedDateProperty =
          BindableProperty.Create(nameof(SelectedDate), typeof(DateTime), typeof(Calendar), DateTime.Today, BindingMode.TwoWay);

        public DateTime SelectedDate
        {
            get => (DateTime) GetValue(SelectedDateProperty);
            set => SetValue(SelectedDateProperty, value);
        }

        public static readonly BindableProperty CultureProperty =
          BindableProperty.Create(nameof(Culture), typeof(CultureInfo), typeof(Calendar), CultureInfo.InvariantCulture, BindingMode.TwoWay);

        public CultureInfo Culture
        {
            get => (CultureInfo) GetValue(CultureProperty);
            set => SetValue(CultureProperty, value);
        }

        public static readonly BindableProperty EventsProperty =
          BindableProperty.Create(nameof(Events), typeof(EventCollection), typeof(Calendar), new EventCollection(), propertyChanged: OnEventsChanged);

        public EventCollection Events
        {
            get => (EventCollection) GetValue(EventsProperty);
            set => SetValue(EventsProperty, value);
        }

        public static readonly BindableProperty SelectedDayEventsProperty =
          BindableProperty.Create(nameof(SelectedDayEvents), typeof(ICollection), typeof(Calendar), new List<object>());

        public ICollection SelectedDayEvents
        {
            get => (ICollection) GetValue(SelectedDayEventsProperty);
            set => SetValue(SelectedDayEventsProperty, value);
        }

        public static readonly BindableProperty EventTemplateProperty =
          BindableProperty.Create(nameof(EventTemplate), typeof(DataTemplate), typeof(Calendar), null);

        public DataTemplate EventTemplate
        {
            get => (DataTemplate) GetValue(EventTemplateProperty);
            set => SetValue(EventTemplateProperty, value);
        }

        public static readonly BindableProperty MonthLabelColorProperty =
          BindableProperty.Create(nameof(MonthLabelColor), typeof(Color), typeof(Calendar), Color.FromHex("#2196F3"));

        public Color MonthLabelColor
        {
            get => (Color) GetValue(MonthLabelColorProperty);
            set => SetValue(MonthLabelColorProperty, value);
        }

        public static readonly BindableProperty YearLabelColorProperty =
          BindableProperty.Create(nameof(YearLabelColor), typeof(Color), typeof(Calendar), Color.FromHex("#2196F3"));

        public Color YearLabelColor
        {
            get => (Color) GetValue(YearLabelColorProperty);
            set => SetValue(YearLabelColorProperty, value);
        }

        public static readonly BindableProperty SelectedDateColorProperty =
          BindableProperty.Create(nameof(SelectedDateColor), typeof(Color), typeof(Calendar), Color.FromHex("#2196F3"));

        public Color SelectedDateColor
        {
            get => (Color) GetValue(SelectedDateColorProperty);
            set => SetValue(SelectedDateColorProperty, value);
        }

        public static readonly BindableProperty DaysTitleColorProperty =
          BindableProperty.Create(nameof(DaysTitleColor), typeof(Color), typeof(Calendar), Color.Default);

        public Color DaysTitleColor
        {
            get => (Color) GetValue(DaysTitleColorProperty);
            set => SetValue(DaysTitleColorProperty, value);
        }

        public static readonly BindableProperty SelectedDayTextColorProperty =
          BindableProperty.Create(nameof(SelectedDayTextColor), typeof(Color), typeof(Calendar), Color.White);

        public Color SelectedDayTextColor
        {
            get => (Color) GetValue(SelectedDayTextColorProperty);
            set => SetValue(SelectedDayTextColorProperty, value);
        }

        public static readonly BindableProperty DeselectedDayTextColorProperty =
          BindableProperty.Create(nameof(DeselectedDayTextColor), typeof(Color), typeof(Calendar), Color.Default);

        public Color DeselectedDayTextColor
        {
            get => (Color) GetValue(DeselectedDayTextColorProperty);
            set => SetValue(DeselectedDayTextColorProperty, value);
        }

        public static readonly BindableProperty OtherMonthDayColorProperty =
          BindableProperty.Create(nameof(OtherMonthDayColor), typeof(Color), typeof(Calendar), Color.Silver);

        public Color OtherMonthDayColor
        {
            get => (Color) GetValue(OtherMonthDayColorProperty);
            set => SetValue(OtherMonthDayColorProperty, value);
        }

        public static readonly BindableProperty SelectedDayBackgroundColorProperty =
          BindableProperty.Create(nameof(SelectedDayBackgroundColor), typeof(Color), typeof(Calendar), Color.FromHex("#2196F3"));

        public Color SelectedDayBackgroundColor
        {
            get => (Color) GetValue(SelectedDayBackgroundColorProperty);
            set => SetValue(SelectedDayBackgroundColorProperty, value);
        }

        public static readonly BindableProperty EventIndicatorColorProperty =
          BindableProperty.Create(nameof(EventIndicatorColor), typeof(Color), typeof(Calendar), Color.FromHex("#FF4081"));

        public Color EventIndicatorColor
        {
            get => (Color) GetValue(EventIndicatorColorProperty);
            set => SetValue(EventIndicatorColorProperty, value);
        }

        public static readonly BindableProperty EventIndicatorSelectedColorProperty =
          BindableProperty.Create(nameof(EventIndicatorSelectedColor), typeof(Color), typeof(Calendar), Color.FromHex("#FF4081"));

        public Color EventIndicatorSelectedColor
        {
            get => (Color) GetValue(EventIndicatorSelectedColorProperty);
            set => SetValue(EventIndicatorSelectedColorProperty, value);
        }

        public static readonly BindableProperty ArrowsHeaderTextColorProperty =
          BindableProperty.Create(nameof(ArrowsHeaderTextColor), typeof(Color), typeof(Calendar), Color.FromHex("#2196F3"));

        public Color ArrowsHeaderTextColor
        {
            get => (Color) GetValue(ArrowsHeaderTextColorProperty);
            set => SetValue(ArrowsHeaderTextColorProperty, value);
        }


        public static readonly BindableProperty ArrowsFooterTextColorProperty =
          BindableProperty.Create(nameof(ArrowsFooterTextColor), typeof(Color), typeof(Calendar), Color.FromHex("#2196F3"));

        public Color ArrowsFooterTextColor
        {
            get => (Color) GetValue(ArrowsFooterTextColorProperty);
            set => SetValue(ArrowsFooterTextColorProperty, value);
        }

        public static readonly BindableProperty ArrowsHeaderFontSizeProperty =
          BindableProperty.Create(nameof(ArrowsHeaderFontSize), typeof(double), typeof(Calendar), Device.GetNamedSize(NamedSize.Medium, typeof(Label)));

        public double ArrowsHeaderFontSize
        {
            get => (double) GetValue(ArrowsHeaderFontSizeProperty);
            set => SetValue(ArrowsHeaderFontSizeProperty, value);
        }

        public static readonly BindableProperty ArrowsFooterFontSizeProperty =
          BindableProperty.Create(nameof(ArrowsFooterFontSize), typeof(double), typeof(Calendar), Device.GetNamedSize(NamedSize.Medium, typeof(Label)));

        public double ArrowsFooterFontSize
        {
            get => (double) GetValue(ArrowsFooterFontSizeProperty);
            set => SetValue(ArrowsFooterFontSizeProperty, value);
        }

        public static readonly BindableProperty ArrowsHeaderBackgroundColorProperty =
          BindableProperty.Create(nameof(ArrowsHeaderBackgroundColor), typeof(Color), typeof(Calendar), Color.White);

        public Color ArrowsHeaderBackgroundColor
        {
            get => (Color) GetValue(ArrowsHeaderBackgroundColorProperty);
            set => SetValue(ArrowsHeaderBackgroundColorProperty, value);
        }

        public static readonly BindableProperty ArrowsHeaderBorderColorProperty =
          BindableProperty.Create(nameof(ArrowsHeaderBorderColor), typeof(Color), typeof(Calendar), Color.White);

        public Color ArrowsHeaderBorderColor
        {
            get => (Color) GetValue(ArrowsHeaderBorderColorProperty);
            set => SetValue(ArrowsHeaderBorderColorProperty, value);
        }

        public static readonly BindableProperty ArrowsFontFamilyProperty =
          BindableProperty.Create(nameof(ArrowsFontFamily), typeof(string), typeof(Calendar), string.Empty);

        public string ArrowsFontFamily
        {
            get => (string) GetValue(ArrowsFontFamilyProperty);
            set => SetValue(ArrowsFontFamilyProperty, value);
        }

        public static readonly BindableProperty ArrowsHasShadowProperty =
          BindableProperty.Create(nameof(ArrowsHasShadow), typeof(bool), typeof(Calendar), true);

        public bool ArrowsHasShadow
        {
            get => (bool)GetValue(ArrowsHasShadowProperty);
            set => SetValue(ArrowsHasShadowProperty, value);
        }

        public static readonly BindableProperty ArrowLeftTextProperty =
          BindableProperty.Create(nameof(ArrowLeftText), typeof(string), typeof(Calendar), "←");

        public string ArrowLeftText
        {
            get => (string) GetValue(ArrowLeftTextProperty);
            set => SetValue(ArrowLeftTextProperty, value);
        }

        public static readonly BindableProperty ArrowRightTextProperty =
          BindableProperty.Create(nameof(ArrowRightText), typeof(string), typeof(Calendar), "→");

        public string ArrowRightText
        {
            get => (string) GetValue(ArrowRightTextProperty);
            set => SetValue(ArrowRightTextProperty, value);
        }

        public static readonly BindableProperty ArrowUpTextProperty =
          BindableProperty.Create(nameof(ArrowUpText), typeof(string), typeof(Calendar), "↑");

        public string ArrowUpText
        {
            get => (string) GetValue(ArrowUpTextProperty);
            set => SetValue(ArrowUpTextProperty, value);
        }

        public static readonly BindableProperty ArrowDownTextProperty =
          BindableProperty.Create(nameof(ArrowDownText), typeof(string), typeof(Calendar), "↓");

        public string ArrowDownText
        {
            get => (string) GetValue(ArrowDownTextProperty);
            set => SetValue(ArrowDownTextProperty, value);
        }

        public static readonly BindableProperty TodayOutlineColorProperty =
          BindableProperty.Create(nameof(TodayOutlineColor), typeof(Color), typeof(Calendar), Color.FromHex("#FF4081"));

        public Color TodayOutlineColor
        {
            get => (Color) GetValue(TodayOutlineColorProperty);
            set => SetValue(TodayOutlineColorProperty, value);
        }

        public static readonly BindableProperty TodayFillColorProperty =
          BindableProperty.Create(nameof(TodayFillColor), typeof(Color), typeof(Calendar), Color.Transparent);

        public Color TodayFillColor
        {
            get => (Color) GetValue(TodayFillColorProperty);
            set => SetValue(TodayFillColorProperty, value);
        }

        public static readonly BindableProperty HeaderSectionTemplateProperty =
          BindableProperty.Create(nameof(HeaderSectionTemplate), typeof(DataTemplate), typeof(Calendar), new DataTemplate(() => new DefaultHeaderSection()));

        public DataTemplate HeaderSectionTemplate
        {
            get => (DataTemplate) GetValue(HeaderSectionTemplateProperty);
            set => SetValue(HeaderSectionTemplateProperty, value);
        }

        public static readonly BindableProperty FooterSectionTemplateProperty =
          BindableProperty.Create(nameof(FooterSectionTemplate), typeof(DataTemplate), typeof(Calendar), new DataTemplate(() => new DefaultFooterSection()));

        public DataTemplate FooterSectionTemplate
        {
            get => (DataTemplate) GetValue(FooterSectionTemplateProperty);
            set => SetValue(FooterSectionTemplateProperty, value);
        }

        public static readonly BindableProperty MonthTextProperty =
          BindableProperty.Create(nameof(MonthText), typeof(string), typeof(Calendar), null);

        public string MonthText
        {
            get => (string) GetValue(MonthTextProperty);
            set => SetValue(MonthTextProperty, value);
        }

        public static readonly BindableProperty SelectedDateTextProperty =
          BindableProperty.Create(nameof(SelectedDateText), typeof(string), typeof(Calendar), null);

        public string SelectedDateText
        {
            get => (string) GetValue(SelectedDateTextProperty);
            set => SetValue(SelectedDateTextProperty, value);
        }

        public static readonly BindableProperty SelectedDateTextFormatProperty =
          BindableProperty.Create(nameof(SelectedDateTextFormat), typeof(string), typeof(Calendar), "d MMM yyyy");

        public string SelectedDateTextFormat
        {
            get => (string) GetValue(SelectedDateTextFormatProperty);
            set => SetValue(SelectedDateTextFormatProperty, value);
        }

        public static readonly BindableProperty CalendarSectionShownProperty =
          BindableProperty.Create(nameof(CalendarSectionShown), typeof(bool), typeof(Calendar), true);

        public bool CalendarSectionShown
        {
            get => (bool) GetValue(CalendarSectionShownProperty);
            set => SetValue(CalendarSectionShownProperty, value);
        }

        public static readonly BindableProperty DayViewSizeProperty =
          BindableProperty.Create(nameof(DayViewSize), typeof(double), typeof(Calendar), 40.0);

        public double DayViewSize
        {
            get => (double) GetValue(DayViewSizeProperty);
            set => SetValue(DayViewSizeProperty, value);
        }

        public static readonly BindableProperty DayViewCornerRadiusProperty =
          BindableProperty.Create(nameof(DayViewCornerRadius), typeof(float), typeof(Calendar), 20f);

        public float DayViewCornerRadius
        {
            get => (float) GetValue(DayViewCornerRadiusProperty);
            set => SetValue(DayViewCornerRadiusProperty, value);
        }

        public static readonly BindableProperty DaysTitleHeightProperty =
          BindableProperty.Create(nameof(DaysTitleHeight), typeof(double), typeof(Calendar), 30.0);

        public double DaysTitleHeight
        {
            get => (double) GetValue(DaysTitleHeightProperty);
            set => SetValue(DaysTitleHeightProperty, value);
        }

        public static readonly BindableProperty DaysLabelStyleProperty =
          BindableProperty.Create(nameof(DaysLabelStyle), typeof(Style), typeof(Calendar), null);

        public Style DaysLabelStyle
        {
            get => (Style) GetValue(DaysLabelStyleProperty);
            set => SetValue(DaysLabelStyleProperty, value);
        }

        public static readonly BindableProperty DaysTitleLabelStyleProperty =
          BindableProperty.Create(nameof(DaysTitleLabelStyle), typeof(Style), typeof(Calendar), null);

        public Style DaysTitleLabelStyle
        {
            get => (Style) GetValue(DaysTitleLabelStyleProperty);
            set => SetValue(DaysTitleLabelStyleProperty, value);
        }

        /// <summary> Bindable propety for DisableSwipeDetection </summary>
        public static readonly BindableProperty DisableSwipeDetectionProperty =
          BindableProperty.Create(nameof(DisableSwipeDetection), typeof(bool), typeof(Calendar), false);

        /// <summary>
        /// <para> Disables the swipe detection (needs testing on iOS) </para>
        /// Could be useful if your superview has its own swipe-detection logic. 
        /// Also see if <seealso cref="SwipeUpCommand"/>, <seealso cref="SwipeUpToHideEnabled"/>, <seealso cref="SwipeLeftCommand"/>, <seealso cref="SwipeRightCommand"/> or <seealso cref="SwipeToChangeMonthEnabled"/> is useful to you.
        /// </summary>
        public bool DisableSwipeDetection
        {
            get => (bool) GetValue(DisableSwipeDetectionProperty);
            set => SetValue(DisableSwipeDetectionProperty, value);
        }

        /// <summary> Bindable property for SwipeUpCommand </summary>
        public static readonly BindableProperty SwipeUpCommandProperty =
          BindableProperty.Create(nameof(SwipeUpCommand), typeof(ICommand), typeof(Calendar), null);

        /// <summary> Activated when user swipes-up over days view </summary>
        public ICommand SwipeUpCommand
        {
            get => (ICommand) GetValue(SwipeUpCommandProperty);
            set => SetValue(SwipeUpCommandProperty, value);
        }

        /// <summary> Bindable property for SwipeUpToHideEnabled </summary>
        public static readonly BindableProperty SwipeUpToHideEnabledProperty =
          BindableProperty.Create(nameof(SwipeUpToHideEnabled), typeof(bool), typeof(Calendar), true);

        /// <summary> Enable/disable default swipe-up action for showing/hiding calendar </summary>
        public bool SwipeUpToHideEnabled
        {
            get => (bool) GetValue(SwipeUpToHideEnabledProperty);
            set => SetValue(SwipeUpToHideEnabledProperty, value);
        }

        /// <summary> Bindable property for SwipeLeftCommand </summary>
        public static readonly BindableProperty SwipeLeftCommandProperty =
          BindableProperty.Create(nameof(SwipeLeftCommand), typeof(ICommand), typeof(Calendar), null);

        /// <summary> Activated when user swipes-left over days view </summary>
        public ICommand SwipeLeftCommand
        {
            get => (ICommand) GetValue(SwipeLeftCommandProperty);
            set => SetValue(SwipeLeftCommandProperty, value);
        }

        /// <summary> Bindable property for SwipeRightCommand </summary>
        public static readonly BindableProperty SwipeRightCommandProperty =
          BindableProperty.Create(nameof(SwipeRightCommand), typeof(ICommand), typeof(Calendar), null);

        /// <summary> Activated when user swipes-right over days view </summary>
        public ICommand SwipeRightCommand
        {
            get => (ICommand) GetValue(SwipeRightCommandProperty);
            set => SetValue(SwipeRightCommandProperty, value);
        }

        /// <summary> Bindable property for SwipeToChangeMonthEnabled </summary>
        public static readonly BindableProperty SwipeToChangeMonthEnabledProperty =
          BindableProperty.Create(nameof(SwipeToChangeMonthEnabled), typeof(bool), typeof(Calendar), true);

        /// <summary> Enable/disable default swipe actions for changing months </summary>
        public bool SwipeToChangeMonthEnabled
        {
            get => (bool) GetValue(SwipeToChangeMonthEnabledProperty);
            set => SetValue(SwipeToChangeMonthEnabledProperty, value);
        }

        /// <summary> Bindable property for MinimumDate </summary>
        public static readonly BindableProperty MinimumDateProperty =
          BindableProperty.Create(nameof(MinimumDate), typeof(DateTime), typeof(Calendar), DateTime.MinValue);

        /// <summary> Minimum date which can be selected </summary>
        public DateTime MinimumDate
        {
            get => (DateTime) GetValue(MinimumDateProperty);
            set => SetValue(MinimumDateProperty, value);
        }

        /// <summary> Bindable property for MaximumDate </summary>
        public static readonly BindableProperty MaximumDateProperty =
          BindableProperty.Create(nameof(MaximumDate), typeof(DateTime), typeof(Calendar), DateTime.MaxValue);

        /// <summary> Maximum date which can be selected </summary>
        public DateTime MaximumDate
        {
            get => (DateTime) GetValue(MaximumDateProperty);
            set => SetValue(MaximumDateProperty, value);
        }

        /// <summary> Bindable property for DisabledDayColor </summary>
        public static readonly BindableProperty DisabledDayColorProperty =
          BindableProperty.Create(nameof(DisabledDayColor), typeof(Color), typeof(Calendar), Color.FromHex("#ECECEC"));

        /// <summary> Color for days which are out of MinimumDate - MaximumDate range </summary>
        public Color DisabledDayColor
        {
            get => (Color) GetValue(DisabledDayColorProperty);
            set => SetValue(DisabledDayColorProperty, value);
        }

        #endregion

        private const uint CalendarSectionAnimationRate = 16;
        private const int CalendarSectionAnimationDuration = 200;
        private const string CalendarSectionAnimationId = nameof(CalendarSectionAnimationId);
        private readonly Animation _calendarSectionAnimateHide;
        private readonly Animation _calendarSectionAnimateShow;
        private bool _calendarSectionAnimating;
        private double _calendarSectionHeight;

        /// <summary>
        /// Calendar plugin for Xamarin.Forms
        /// </summary>
        public Calendar()
        {
            PrevMonthCommand = new Command(PrevMonth);
            NextMonthCommand = new Command(NextMonth);
            PrevYearCommand = new Command(PrevYear);
            NextYearCommand = new Command(NextYear);
            ShowHideCalendarCommand = new Command(ToggleCalendarSectionVisibility);

            InitializeComponent();
            UpdateSelectedDateLabel();
            UpdateMonthLabel();
            UpdateEvents();
            UpdateEventColors();

            _calendarSectionAnimateHide = new Animation(AnimateMonths, 1, 0);
            _calendarSectionAnimateShow = new Animation(AnimateMonths, 0, 1);

            calendarContainer.SizeChanged += OnCalendarContainerSizeChanged;
        }

        private void UpdateEventColors()
        {
            monthDaysView.UpdateDaysColors();
        }

        #region Properties

        /// <summary>
        /// When executed calendar moves to previous month.
        /// Read only command to use in your <see cref="HeaderSectionTemplate"/> or <see cref="FooterSectionTemplate"/>
        /// </summary>
        public ICommand PrevMonthCommand { get; }

        /// <summary>
        /// When executed calendar moves to next month.
        /// Read only command to use in your <see cref="HeaderSectionTemplate"/> or <see cref="FooterSectionTemplate"/>
        /// </summary>
        public ICommand NextMonthCommand { get; }

        /// <summary>
        /// When executed calendar moves to previous year.
        /// Read only command to use in your <see cref="HeaderSectionTemplate"/> or <see cref="FooterSectionTemplate"/>
        /// </summary>
        public ICommand PrevYearCommand { get; }

        /// <summary>
        /// When executed calendar moves to next year.
        /// Read only command to use in your <see cref="HeaderSectionTemplate"/> or <see cref="FooterSectionTemplate"/>
        /// </summary>
        public ICommand NextYearCommand { get; }

        /// <summary>
        /// When executed shows/hides the calendar's current month days view.
        /// Read only command to use in your <see cref="HeaderSectionTemplate"/> or <see cref="FooterSectionTemplate"/>
        /// </summary>
        public ICommand ShowHideCalendarCommand { get; }

        #endregion

        #region PropertyChanged

        private static void OnEventsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Calendar view)
            {
                if (oldValue is EventCollection oldEvents)
                    oldEvents.CollectionChanged -= view.OnEventsCollectionChanged;

                if (newValue is EventCollection newEvents)
                    newEvents.CollectionChanged += view.OnEventsCollectionChanged;

                view.UpdateEvents();
                view.monthDaysView.UpdateDays();
            }
        }

        /// <summary> Method that is called when a bound property is changed. </summary>
        /// <param name="propertyName">The name of the bound property that changed.</param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(Month):
                    UpdateMonthLabel();
                    break;

                case nameof(SelectedDate):
                    UpdateSelectedDateLabel();
                    UpdateEvents();
                    break;

                case nameof(Culture):
                    if (Month > 0)
                        UpdateMonthLabel();

                    UpdateSelectedDateLabel();
                    break;

                case nameof(CalendarSectionShown):
                    ShowHideCalendarSection();
                    break;
            }
        }

        private void UpdateEvents()
        {
            if (Events.TryGetValue(SelectedDate, out var dayEvent))
            {
                SelectedDayEvents = dayEvent.DayEvents;
                eventsScrollView.ScrollToAsync(0, 0, false);
            }
            else
                SelectedDayEvents = null;
        }

        private void UpdateMonthLabel()
        {
            MonthText = Culture.DateTimeFormat.MonthNames[Month - 1].Capitalize();
        }

        private void UpdateSelectedDateLabel()
        {
            SelectedDateText = SelectedDate.ToString(SelectedDateTextFormat, Culture);
        }

        private void ShowHideCalendarSection()
        {
            if (_calendarSectionAnimating)
                return;

            _calendarSectionAnimating = true;

            var animation = CalendarSectionShown ? _calendarSectionAnimateShow : _calendarSectionAnimateHide;
            var prevState = CalendarSectionShown;

            animation.Commit(this, CalendarSectionAnimationId, CalendarSectionAnimationRate, CalendarSectionAnimationDuration, finished: (value, cancelled) =>
            {
                _calendarSectionAnimating = false;

                if (prevState != CalendarSectionShown)
                    ToggleCalendarSectionVisibility();
            });
        }

        private void UpdateCalendarSectionHeight()
        {
            _calendarSectionHeight = calendarContainer.Height;
        }

        private void OnEventsCollectionChanged(object sender, EventCollection.EventCollectionChangedArgs e)
        {
            UpdateEvents();
            monthDaysView.UpdateDays();
        }

        #endregion

        #region Event Handlers

        private void OnCalendarContainerSizeChanged(object sender, EventArgs e)
        {
            if (calendarContainer.Height > 0 && !_calendarSectionAnimating)
                UpdateCalendarSectionHeight();
        }

        private void OnSwipedRight(object sender, EventArgs e)
        {
            SwipeRightCommand?.Execute(null);

            if (SwipeToChangeMonthEnabled)
                PrevMonth();
        }

        private void OnSwipedLeft(object sender, EventArgs e)
        {
            SwipeLeftCommand?.Execute(null);

            if (SwipeToChangeMonthEnabled)
                NextMonth();
        }

        private void OnSwipedUp(object sender, EventArgs e)
        {
            SwipeUpCommand?.Execute(null);

            if (SwipeUpToHideEnabled)
                ToggleCalendarSectionVisibility();
        }

        #endregion

        #region Other methods

        private void PrevMonth()
        {
            int newMonth;
            int newYear = Year;

            if (Month - 1 == 0)
            {
                newMonth = 12;
                newYear = Year - 1;
            }
            else
                newMonth = Month - 1;

            if (CheckMinimumDate(newYear, newMonth))
            {
                Month = newMonth;
                Year = newYear;
            }
        }

        private void NextMonth()
        {
            int newMonth;
            int newYear = Year;

            if (Month + 1 == 13)
            {
                newMonth = 1;
                newYear = Year + 1;
            }
            else
                newMonth = Month + 1;

            if (CheckMaximumDate(newYear, newMonth))
            {
                Month = newMonth;
                Year = newYear;
            }
        }

        private void PrevYear()
        {
            if (CheckMinimumDate(Year - 1, Month))
                Year--;
        }

        private void NextYear()
        {
            if (CheckMaximumDate(Year + 1, Month))
                Year++;
        }

        private void ToggleCalendarSectionVisibility()
            => CalendarSectionShown = !CalendarSectionShown;

        private void AnimateMonths(double currentValue)
        {
            calendarSectionRow.Height = new GridLength(_calendarSectionHeight * currentValue);
            calendarContainer.TranslationY = _calendarSectionHeight * (currentValue - 1);
            calendarContainer.Opacity = currentValue * currentValue * currentValue;
        }

        private bool CheckMinimumDate(int year, int month)
        {
            if (year < MinimumDate.Year ||
                year == MinimumDate.Year && month < MinimumDate.Month)
                return false;

            return true;
        }

        private bool CheckMaximumDate(int year, int month)
        {
            if (year > MaximumDate.Year ||
                year == MaximumDate.Year && month > MaximumDate.Month)
                return false;

            return true;
        }

        #endregion

        public static readonly BindableProperty TappedActionDayProperty =
        BindableProperty.Create(nameof(TappedActionDay), typeof(Action<DateTime>), typeof(Calendar));
        public Action<DateTime> TappedActionDay
        {
            get => (Action<DateTime>) GetValue(TappedActionDayProperty);
            set => SetValue(TappedActionDayProperty, value);
        }

    }
}
