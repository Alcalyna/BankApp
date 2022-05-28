using MoneyInTheBank.Model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MoneyInTheBank.ViewModel
{
    public class CategoryBoolean : ViewModelCommon
    {
        public string CategoryName { get; set; }
        public Category Category { get; set; }
        public string NameToDisplay { get; set; }
        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value, NotifyCheckedUnchecked);
        }

        private void NotifyCheckedUnchecked()
        {
            NotifyColleagues(App.Messages.CATEGORY_CHECKED_CHANGED, this);
        }

        public CategoryBoolean(Category category)
        {
            this.Category = category;
            this.NameToDisplay = category.Name;
        }
        public CategoryBoolean(Category category, string NameToDisplay)
        {
            this.CategoryName = CategoryName;
            this.NameToDisplay = NameToDisplay;
        }
    }
    public class AccountDetailViewModel : ViewModelCommon
    {
        private InternalAccount _internalAccount;
        public InternalAccount InternalAccount
        {
            get => _internalAccount;
            set => SetProperty(ref _internalAccount, value, OnRefreshData);
        }
        private Client _client;
        public Client Client
        {
            get => _client;
            set => SetProperty(ref _client, value);
        }
        private DateTime _currentDateTime;
        public DateTime CurrentDateTime
        {
            get => _currentDateTime;
            set => SetProperty(ref _currentDateTime, value, OnRefreshData);
        }

        private ObservableCollection<Transaction> _transactions = new();
        public ObservableCollection<Transaction> Transactions
        {
            get => _transactions;
            set => SetProperty(ref _transactions, value);
        }

        private ObservableCollection<Category> _categories = new();
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        private ObservableCollection<string> _timePeriods = new();
        public ObservableCollection<string> TimePeriods
        {
            get => _timePeriods;
            set => SetProperty(ref _timePeriods, value);
        }

        private ObservableCollection<CategoryBoolean> _categoriesBooleans = new();
        public ObservableCollection<CategoryBoolean> CategoriesBooleans
        {
            get => _categoriesBooleans;
            set => SetProperty(ref _categoriesBooleans, value);
        }

        private string _selectedTimePeriod;
        public string SelectedTimePeriod
        {
            get => _selectedTimePeriod;
            set => SetProperty(ref _selectedTimePeriod, value, UpdatePeriod);
        }
        public ICommand ClearFilter { get; set; }
        public ICommand SelectAllCommand { get; set; }
        public ICommand SelectNoneCommand { get; set; }
        public ObservableCollection<Category> SelectedCategories { get; set; } = new();

        private ObservableCollection<Category> _selectedCategory = new();
        public ObservableCollection<Category> SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        public ObservableCollectionFast<TransactionCardViewModel> TransactionsVMs { get; set; } = new();

        public AccountDetailViewModel() : base()
        {
            Register<DateTime>(App.Messages.DATE_CHANGED, date => { CurrentDateTime = date; });
            Register<CategoryBoolean>(App.Messages.CATEGORY_CHECKED_CHANGED, categoryBoolean => UpdateCategory(categoryBoolean));
            Register<Transaction>(App.Messages.CATEGORY_CHANGED, transaction => { OnRefreshData(); });
            Register(App.Messages.TRANSACTION_CANCELED, OnRefreshData);
            Register(App.Messages.TRANSACTION_CREATED, OnRefreshData);
            
            SelectAllCommand = new RelayCommand(() => SelectAllCategories());
            SelectNoneCommand = new RelayCommand(() => SelectNoCategory());
            ClearFilter = new RelayCommand(() => Filter = "");
            FirstPageCommand = new RelayCommand(FirstPageAction, CanFirstPageAction);
            PreviousPageCommand = new RelayCommand(PreviousPageAction, CanPreviousPageAction);
            NextPageCommand = new RelayCommand(NextPageAction, CanNextPageAction);
            LastPageCommand = new RelayCommand(LastPageAction, CanLastPageAction);

            CurrentDateTime = CurrentDate;
            Categories = new ObservableCollection<Category>(Category.GetAll());
            SetCategoriesToDisplay();
            Client = GetCurrentClient();
            PastTransactions = true;
            SelectAllCategories();
            AddTimePeriods();
            SelectedTimePeriod = "All";
            CurrentPage = 1;
        }

        private void FirstPageAction()
        {
            CurrentPage = 1;
            OnRefreshData();
        }

        private bool CanFirstPageAction() => CurrentPage > 1;
        private void PreviousPageAction()
        {
            --CurrentPage;
            OnRefreshData();
        }

        private bool CanPreviousPageAction() => CurrentPage > 1;
        private void NextPageAction()
        {
            ++CurrentPage;
            OnRefreshData();
        }

        private bool CanNextPageAction() => CurrentPage < NumberOfPages;
        private void LastPageAction()
        {
            CurrentPage = NumberOfPages;
            OnRefreshData();
        }

        private bool CanLastPageAction() => CurrentPage != NumberOfPages;

        private void UpdateCategory(CategoryBoolean categoryBoolean)
        {
            if(categoryBoolean.IsChecked)
                AddCategory(categoryBoolean);
            else
                RemoveCategory(categoryBoolean);
            OnRefreshData();
        }
        private void AddCategory(CategoryBoolean categoryBoolean)
        {
            SelectedCategory.Add(categoryBoolean.Category);
        }

        private void RemoveCategory(CategoryBoolean categoryBoolean)
        {
            SelectedCategory.Remove(categoryBoolean.Category);
        }

        private void SelectAllCategories()
        {
            SelectedCategory.Clear();
            foreach(CategoryBoolean categoryBoolean in CategoriesBooleans)
            {
                categoryBoolean.IsChecked = true;
                SelectedCategory.Add(categoryBoolean.Category);
            }
            OnRefreshData();
        }

        private void SelectNoCategory()
        {
            SelectedCategory.Clear();
            foreach (CategoryBoolean categoryBoolean in CategoriesBooleans)
            {
                categoryBoolean.IsChecked = false;
            }
            OnRefreshData();

        }

        private void SetCategoriesToDisplay()
        {
            foreach(Category category in Categories)
            {
                CategoriesBooleans.Add(new CategoryBoolean(category));
            }
            CategoriesBooleans.Add(new CategoryBoolean(null, "<No Category>"));
        }
      
        private void AddTimePeriods()
        {
            TimePeriods.Add("1 Day");
            TimePeriods.Add("1 Week");
            TimePeriods.Add("2 Weeks");
            TimePeriods.Add("1 Month");
            TimePeriods.Add("1 Year");
            TimePeriods.Add("All");
        }
        private Boolean OneDay { get; set; }
        private Boolean OneWeek { get; set; }
        private Boolean TwoWeeks { get; set; }
        private Boolean OneMonth { get; set; }
        private Boolean OneYear { get; set; }
        private Boolean AllPeriod { get; set; }
        private void UpdatePeriod()
        {
            OneDay = false;
            OneWeek = false;
            TwoWeeks = false;
            OneMonth = false;
            OneYear = false;
            AllPeriod = false;
            switch (SelectedTimePeriod)
            {
                case "1 Day":
                    OneDay = true;
                    break;
                case "1 Week":
                    OneWeek = true;
                    break;
                case "2 Weeks":
                    TwoWeeks = true;
                    break;
                case "1 Month":
                    OneMonth = true;
                    break;
                case "1 Year":
                    OneYear = true;
                    break;
                case "All":
                    AllPeriod = true;
                    break;
            }
            OnRefreshData();
        }

        private bool _futureTransactions;
        public bool FutureTransactions
        {
            get => _futureTransactions;
            set => SetProperty(ref _futureTransactions, value, OnRefreshData);
        }

        private bool _pastTransactions;
        public bool PastTransactions
        {
            get => _pastTransactions;
            set => SetProperty(ref _pastTransactions, value, () => SetPastTransactions(value));
        }

        private void SetPastTransactions(bool isChecked)
        {
            if(!isChecked)
            {
                RefusedTransactions = false;
            }
            RaisePropertyChanged();
            OnRefreshData();
        }

        private bool _refusedTransactions = false;
        public bool RefusedTransactions
        {
            get => _refusedTransactions;
            set => SetProperty(ref _refusedTransactions, value, () => SetRefusedTransactions(value));
        }

        private void SetRefusedTransactions(bool isChecked)
        {
            if(isChecked)
                PastTransactions = true;
            RaisePropertyChanged();
            OnRefreshData();
        }

        private string _filter;
        public string Filter
        {
            get => _filter;
            set => SetProperty(ref _filter, value, OnRefreshData);
        }

        public string Iban
        {
            get => InternalAccount.Iban;
        }

        private ObservableCollection<Category> _selectedItems = new();
        public ObservableCollection<Category> SelectedItems
        {
            get => _selectedItems;
            set => SetProperty(ref _selectedItems, value);
        }
        public void Init(InternalAccount internalAccount)
        {
            InternalAccount = internalAccount;
            RaisePropertyChanged();
        }

        protected override void OnRefreshData()
        {
            IQueryable<Transaction> transactions = Transaction.GetAll();
            Transaction.ComputeBalance(transactions, CurrentDateTime);
            var filteredTransactions = transactions.AsEnumerable()
                                      .Where(t => t.Source == InternalAccount || t.Recipient == InternalAccount)
                                      .Where(t => t.TransactionStatus != Status.NOT_DISPLAYED)
                                      .Where(t => PastTransactions && t.ActionDateTime <= CurrentDateTime || FutureTransactions && t.ActionDateTime > CurrentDateTime)
                                      .Where(t => (AllPeriod) || (OneDay && t.ActionDateTime >= CurrentDateTime) || (OneWeek && t.ActionDateTime >= CurrentDateTime.AddDays(-7)) || (TwoWeeks && t.ActionDateTime >= CurrentDateTime.AddDays(-14)) || (OneMonth && t.ActionDateTime >= CurrentDateTime.AddMonths(-1)) || (OneYear && t.ActionDateTime >= CurrentDateTime.AddYears(-1)))
                                      .Where(t => string.IsNullOrEmpty(Filter) || !string.IsNullOrEmpty(Filter) && (t.Source.Iban.ToUpper().Contains(Filter.ToUpper()) || t.Recipient.Iban.Contains(Filter) || t.Description.Contains(Filter) || t.Amount.ToString().Contains(Filter) || t.Source.Description.ToUpper().Contains(Filter.ToUpper()) || t.Recipient.Description.Contains(Filter) || t.Principal.FirstName.ToUpper().Contains(Filter.ToUpper()) || t.Principal.LastName.ToUpper().Contains(Filter.ToUpper())))
                                      .Where(t => SelectedCategory.Contains(t.Category))
                                      .Where(t => RefusedTransactions || !RefusedTransactions && t.TransactionStatus != Status.REFUSED)
                                      .Where(t => t.Recipient != InternalAccount || t.TransactionStatus != Status.REFUSED)
                                      .Where(t => !(t.TransactionStatus == Status.NOT_EXECUTED && t.Recipient == InternalAccount))
                                      .OrderByDescending(t => t.ActionDateTime)
                                      .ThenByDescending(t => t.CreationDateTime)
                                      .ToList();
            TransactionsVMs.Clear();
            if (filteredTransactions.Count != 0)
            {
                List<Transaction> displayingTransactions = GetTransactionsToDisplayPagination(filteredTransactions);
                AddViewModelToList(displayingTransactions);
            }
            else
                ResetPaginationFeatures();
            Transactions = new ObservableCollection<Transaction>(filteredTransactions);

        }

        private List<Transaction> GetTransactionsToDisplayPagination(List<Transaction> filteredTransactions)
        {
            int numberOfElements = filteredTransactions.Count;
            NumberOfPages = (int)Math.Ceiling(((double)numberOfElements / (double)PageSize));
            if (CurrentPage > NumberOfPages || CurrentPage == 0)
                CurrentPage = 1;
            var displayingTransactions = filteredTransactions.AsEnumerable().Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            StartDate = displayingTransactions[0].ActionDateTime;
            EndDate = displayingTransactions[displayingTransactions.Count - 1].ActionDateTime;
            return displayingTransactions;
        }

        private void ResetPaginationFeatures()
        {
            NumberOfPages = 0;
            CurrentPage = 0;
            StartDate = null;
            EndDate = null;
        }

        private void AddViewModelToList(List<Transaction> displayingTransactions)
        {
            foreach (Transaction transaction in displayingTransactions)
            {
                TransactionCardViewModel transactionCardViewModel = new TransactionCardViewModel(transaction, InternalAccount);
                transactionCardViewModel.Categories = this.Categories;
                bool containsNoCategory = transactionCardViewModel.Categories.Any(c => c.Name == "");
                if (!containsNoCategory)
                    transactionCardViewModel.Categories.Add(new Category(""));
                TransactionsVMs.Add(transactionCardViewModel);
            }
        }

        private int _currentPage;
        public int CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }
        private int _numberOfPages;
        public int NumberOfPages
        {
            get => _numberOfPages;
            set => SetProperty(ref _numberOfPages, value);
        }
        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public ICommand FirstPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand LastPageCommand { get; set; }
        private int PageSize { get; set; } = 4;
        
    }
}
