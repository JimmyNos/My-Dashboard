using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

//using My_Dashboard.Core;
using My_Dashboard.MVVM.View;
using My_Dashboard.MVVM.ViewModel.Computer;
using My_Dashboard.MVVM.ViewModel.Laptop;
using My_Dashboard.MVVM.ViewModel.Nas;

namespace My_Dashboard.MVVM.ViewModel
{
    internal partial class MainViewModel : ObservableObject
    {
        // Properties with ObservableProperty
        [ObservableProperty]
        private object _currentView;

        [ObservableProperty]
        private object _currentSideView;

        public RelayCommand DashboardViewCommand { get; set; }
        public RelayCommand GraphsViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }

        // ViewModels
        public ComputerSideBarViewModel ComputerSideBarVM { get; } = new();
        public LaptopSideBarViewModel LaptopSideBarVM { get; } = new();
        public NasSideBarViewModel NasSideBarVM { get; } = new();

        public ComputerDashboardViewModel ComputerDashboardVM { get; } = new();
        public ComputerGraphsViewModel ComputerGraphsVM { get; } = new();
        public ComputerSettingsViewModel ComputerSettingsVM { get; } = new();

        public LaptopDashboardViewModel LaptopDashboardVM { get; } = new();
        public LaptopGraphsViewModel LaptopGraphsVM { get; } = new();
        public LaptopSettingsViewModel LaptopSettingsVM { get; } = new();

        public NasDashboardViewModel NasDashboardVM { get; } = new();
        public NasGraphsViewModel NasGraphsVM { get; } = new();
        public NasSettingsViewModel NasSettingsVM { get; } = new();

        // Commands
        [RelayCommand]
        private void SwitchToComputerSideBar()
        {
            CurrentSideView = ComputerSideBarVM;
            CurrentView = ComputerDashboardVM;
            Console.WriteLine("Switched to Computer SideBar");
        }

        [RelayCommand]
        private void SwitchToLaptopSideBar()
        {
            CurrentSideView = LaptopSideBarVM;
            CurrentView = LaptopDashboardVM;
            Console.WriteLine("Switched to Laptop SideBar");
        }

        [RelayCommand]
        private void SwitchToNasSideBar()
        {
            CurrentSideView = NasSideBarVM;
            CurrentView = NasDashboardVM;
            Console.WriteLine("Switched to NAS SideBar");
        }

        [RelayCommand]
        private void ShowDashboardView()
        {
            if (CurrentSideView == ComputerSideBarVM)
                CurrentView = ComputerDashboardVM;
            else if (CurrentSideView == LaptopSideBarVM)
                CurrentView = LaptopDashboardVM;
            else if (CurrentSideView == NasSideBarVM)
                CurrentView = NasDashboardVM;

            Console.WriteLine("Dashboard View Displayed");
        }

        [RelayCommand]
        private void ShowGraphsView()
        {
            if (CurrentSideView == ComputerSideBarVM)
                CurrentView = ComputerGraphsVM;
            else if (CurrentSideView == LaptopSideBarVM)
                CurrentView = LaptopGraphsVM;
            else if (CurrentSideView == NasSideBarVM)
                CurrentView = NasGraphsVM;

            Console.WriteLine("Graphs View Displayed");
        }

        [RelayCommand]
        private void ShowSettingsView()
        {
            if (CurrentSideView == ComputerSideBarVM)
                CurrentView = ComputerSettingsVM;
            else if (CurrentSideView == LaptopSideBarVM)
                CurrentView = LaptopSettingsVM;
            else if (CurrentSideView == NasSideBarVM)
                CurrentView = NasSettingsVM;

            Console.WriteLine("Settings View Displayed");
        }

        // Constructor
        public MainViewModel()
        {
            CurrentView = ComputerDashboardVM;
            CurrentSideView = ComputerSideBarVM;
        }
    }
}
