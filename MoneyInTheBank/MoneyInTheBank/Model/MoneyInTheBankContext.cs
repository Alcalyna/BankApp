using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRBD_Framework;

namespace MoneyInTheBank.Model
{
    public class MoneyInTheBankContext : DbContextBase
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Information)
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=moneyinthebank")
                .UseLazyLoadingProxies(true)
                 ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientInternalAccount>().HasKey(c => new { c.ClientId, c.InternalAccountId });
            modelBuilder.Entity<Transaction>().HasOne(t => t.Recipient).WithMany(a => a.TransactionsIn).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Transaction>().HasOne(t => t.Source).WithMany(a => a.TransactionsOut).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Agency>().HasOne(a => a.Manager).WithMany(m => m.Agencies).OnDelete(DeleteBehavior.ClientCascade);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public DbSet<ExternalAccount> ExternalAccounts { get; set; }
        public DbSet<InternalAccount> InternalAccounts { get; set; }
        public DbSet<SavingAccount> SavingAccounts { get; set; }
        public DbSet<ClientInternalAccount> ClientInternalAccounts { get; set; }
        public DbSet<ClientCheckingAccount> ClientCheckingAccounts { get; set; }
        public DbSet<ClientSavingAccount> ClientSavingAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Agency> Agencies { get; set; }

        public void SeedData()
        {
            Database.BeginTransaction();
            //    var calinh = new Manager { FirstName = "Calinh", LastName = "Corp", Email = "calinh@moneyinthebank.com", Password = "calinh" };

            //    Agency agencyCalinh = new Agency { Name = "Calinh Agency", Manager = calinh };
            //    Agency tradingAgency = new Agency { Name = "Trading Agency", Manager = calinh };
            //    Agency moneyInMyBank = new Agency { Name = "Money In My Bank", Manager = calinh };

            //    Agencies.AddRange(agencyCalinh, tradingAgency, moneyInMyBank);

            //    var linh = new Client { FirstName = "Linh", LastName = "Nguyen", Email = "linh@moneyinthebank.com", Password = "linh", ClientNumber = "12708", Agency =  agencyCalinh};
            //    var alexei = new Client { FirstName = "Alexei", LastName = "Revenko", Email = "alexei@moneyinthebank.com", Password = "alexei", ClientNumber = "68814", Agency = agencyCalinh };
            //    var bruno = new Client { FirstName = "Bruno", LastName = "Lacroix", Email = "bruno@moneyinthebank.com", Password = "bruno", ClientNumber = "49553", Agency = agencyCalinh };

            //    //Users.AddRange(linh, alexei);
            //    Clients.AddRange(linh, alexei, bruno);
            //    Managers.AddRange(calinh);

            //    var commonCheckingAccount = new CheckingAccount { Iban = new IBAN("BE32999775314202"), Description = "My common checking account bro", LowerLimit = 0 };
            //    var checkingAccount1 = new CheckingAccount { Iban = (new IBAN("BE05878459468275")).ToString(), Description = "My first checking account bro", LowerLimit = -350 };
            //    var checkingAccount2 = new CheckingAccount { Iban = (new IBAN("BE23817751321491")).ToString(), Description = "My second checking account bro", LowerLimit = -200 };


            //    ClientInternalAccounts.AddRange(
            //        new ClientCheckingAccount { Client = linh, InternalAccount = checkingAccount1, Relation = ClientInternalAccount.RelationType.OWNER },
            //        new ClientCheckingAccount { Client = linh, InternalAccount = checkingAccount2, Relation = ClientInternalAccount.RelationType.OWNER},
            //        new ClientCheckingAccount { Client = linh, InternalAccount = commonCheckingAccount, Relation = ClientInternalAccount.RelationType.PROXY},
            //        new ClientCheckingAccount { Client = alexei, InternalAccount = commonCheckingAccount, Relation = ClientInternalAccount.RelationType.OWNER }
            //    );


            //    var savingAccount1 = new SavingAccount { Iban = (new IBAN("BE65561343326196")).ToString(), Description = "First saving account" };
            //    var savingAccount2 = new SavingAccount { Iban = (new IBAN("BE07954716482966")).ToString(), Description = "Second saving account" };

            //    ClientInternalAccounts.AddRange(
            //        new ClientSavingAccount { Client = linh, InternalAccount = savingAccount1, Relation = ClientInternalAccount.RelationType.OWNER },
            //        new ClientSavingAccount { Client = linh, InternalAccount = savingAccount2, Relation = ClientInternalAccount.RelationType.PROXY }
            //    );

            //    var externalAccount = new ExternalAccount { Iban = (new IBAN("BE80233853582977")).ToString(), Description = "Not in Money In the Bank" };

            //    ExternalAccounts.AddRange(externalAccount);

            //    var rent = new Category { Name = "Rent" };
            //    var electricity = new Category { Name = "Electricity" };
            //    var childSupport = new Category { Name = "Child support" };
            //    var shopping = new Category { Name = "Shopping" };
            //    var bribe = new Category { Name = "Bribe" };
            //    var saving = new Category { Name = "Saving" };
            //    Categories.AddRange(rent, electricity, childSupport, shopping, bribe, saving);

            //    var transaction1 = new Transaction { Principal = linh, Amount = 20, Description = "First transaction", Source = checkingAccount1, Recipient = externalAccount, ActionDateTime = new DateTime(2019, 05, 17, 17, 10, 20), CreationDateTime = new DateTime(2019, 05, 16, 17, 10, 20) };
            //    var transaction2 = new Transaction { Principal = linh, Amount = 35.5, Description = "Second transaction", Source = checkingAccount1, Recipient = externalAccount, ActionDateTime = new DateTime(2020, 05, 17, 5, 10, 20), CreationDateTime = new DateTime(2020, 05, 15, 17, 10, 20) };
            //var transaction3 = new Transaction { Principal = linh, Amount = 135.35, Description = "First transaction", Source = checkingAccount2, Recipient = externalAccount, ActionDateTime = new DateTime(2021, 05, 17, 5, 10, 20), CreationDateTime = new DateTime(2021, 05, 13, 17, 10, 20) };
            //    var transaction4 = new Transaction { Principal = linh, Amount = 35, Description = "First transaction", Source = savingAccount1, Recipient = externalAccount, ActionDateTime = new DateTime(2021, 05, 17, 0, 0, 0), Category = bribe, CreationDateTime = new DateTime(2021, 05, 16, 16, 10, 20) };

            //    var transaction5 = new Transaction { Principal = linh, Amount = 500, Description = "First transaction", Source = checkingAccount2, Recipient = externalAccount, ActionDateTime = new DateTime(2019, 05, 17, 5, 10, 20), CreationDateTime = new DateTime(2019, 05, 16, 17, 10, 20) };

            //    var transaction6 = new Transaction { Principal = linh, Amount = 35.35, Description = "Saving a bit", Source = checkingAccount1, Recipient = savingAccount1, ActionDateTime = new DateTime(2021, 05, 16, 0, 0, 0), Category = saving, CreationDateTime = new DateTime(2021, 05, 14, 17, 10, 20) };

            //    var transaction7 = new Transaction { Principal = linh, Amount = 15, Source = checkingAccount1, Recipient = savingAccount2, ActionDateTime = new DateTime(2021, 05, 16, 18, 10, 36), Category = saving, CreationDateTime = new DateTime(2021, 05, 14, 17, 10, 20) };

            //    Transactions.AddRange(transaction1, transaction2, transaction3, transaction4, transaction5, transaction6, transaction7);
            Admin admin = new Admin { FirstName = "Admin", LastName = "Istrateur", Email = "admin@test.com", Password = "admin" };
            Admins.Add(admin);

            Manager manager1 = new Manager { FirstName = "bruno", LastName = "Lacroix", Email = "bruno@test.com", Password = "bruno" };
            Manager manager2 = new Manager { FirstName = "ben", LastName = "Penelle", Email = "ben@test.com", Password = "ben" };
            Managers.Add(manager1);
            Managers.Add(manager2);

            Agency agency1 = new Agency { Name = "Agency1", Manager = manager2 };
            Agency agency2 = new Agency { Name = "Agency2", Manager = manager2 };
            Agency agency3 = new Agency { Name = "Agency3", Manager = manager1 };
            Agencies.Add(agency1);
            Agencies.Add(agency2);
            Agencies.Add(agency3);

            Client client4 = new Client { FirstName = "Bob", LastName = "Marley", Email = "bob@test.com", Password = "bob", ClientNumber = "0004", Agency = agency1 };
            Client client5 = new Client { FirstName = "Caroline", LastName = "de Monaco", Email = "caro@test.com", Password = "caro", ClientNumber = "0005", Agency = agency1 };
            Client client6 = new Client { FirstName = "Louise", LastName = "TheCross", Email = "louise@test.com", Password = "louise", ClientNumber = "0006", Agency = agency2 };
            Client client7 = new Client { FirstName = "Jules", LastName = "TheCross", Email = "jules@test.com", Password = "jules", ClientNumber = "0007", Agency = agency2 };
            Client client8 = new Client { FirstName = "Linh", LastName = "Nguyen", Email = "linh@test.com", Password = "linh", ClientNumber = "0008", Agency = agency2 };
            Clients.Add(client4);
            Clients.Add(client5);
            Clients.Add(client6);
            Clients.Add(client7);
            Clients.Add(client8);

            Category category1 = new Category { Name = "Category1" };
            Category category2 = new Category { Name = "Category2" };
            Category category3 = new Category { Name = "Category3" };
            Category category4 = new Category { Name = "Category4" };
            Category category5 = new Category { Name = "Category5" };
            Categories.Add(category1);
            Categories.Add(category2);
            Categories.Add(category3);
            Categories.Add(category4);
            Categories.Add(category5);

            ExternalAccount externalAccount = new ExternalAccount { Iban = (new IBAN("BE23008168700358")).ToString(), Description = "EEE" };
            ExternalAccounts.AddRange(externalAccount);

            CheckingAccount checkingAccount1 = new CheckingAccount { Iban = (new IBAN("BE02999910178207")).ToString(), Description = "AAA", LowerLimit = -50 };
            CheckingAccount checkingAccount2 = new CheckingAccount { Iban = (new IBAN("BE14999616694306")).ToString(), Description = "BBB", LowerLimit = -10 };
            CheckingAccount checkingAccount3 = new CheckingAccount { Iban = (new IBAN("BE55999967179982")).ToString(), Description = "DDD", LowerLimit = -100 };
            CheckingAccounts.AddRange(checkingAccount1);
            CheckingAccounts.AddRange(checkingAccount2);
            CheckingAccounts.AddRange(checkingAccount3);

            SavingAccount savingAccount = new SavingAccount { Iban = (new IBAN("BE71999159874787")).ToString(), Description = "CCC" };
            SavingAccounts.AddRange(savingAccount);

            ClientInternalAccounts.AddRange(
                new ClientCheckingAccount { Client = client4, InternalAccount = checkingAccount1, Relation = ClientInternalAccount.RelationType.OWNER }, 
                new ClientCheckingAccount { Client = client8, InternalAccount = checkingAccount1, Relation = ClientInternalAccount.RelationType.OWNER }, 
                new ClientCheckingAccount { Client = client4, InternalAccount = checkingAccount2, Relation = ClientInternalAccount.RelationType.OWNER }, 
                new ClientCheckingAccount { Client = client4, InternalAccount = savingAccount, Relation = ClientInternalAccount.RelationType.PROXY }, 
                new ClientCheckingAccount { Client = client5, InternalAccount = checkingAccount1, Relation = ClientInternalAccount.RelationType.PROXY }, 
                new ClientCheckingAccount { Client = client5, InternalAccount = checkingAccount3, Relation = ClientInternalAccount.RelationType.OWNER }, 
                new ClientCheckingAccount { Client = client5, InternalAccount = savingAccount, Relation = ClientInternalAccount.RelationType.OWNER }
                
                );

            Transaction transaction1 = new Transaction { Principal = client4, Amount = 15, Description = "Tx #014", Source = checkingAccount1, Recipient = checkingAccount2, CreationDateTime = new DateTime(2022, 1, 15, 0, 0, 0) };
            Transaction transaction2 = new Transaction { Amount = 5, Description = "Tx #007", Source = externalAccount, Recipient = savingAccount, CreationDateTime = new DateTime(2022, 1, 4, 0, 0, 0), ActionDateTime = new DateTime(2022, 1, 8, 0, 0, 0) };
            Transaction transaction3 = new Transaction { Principal = client4, Amount = 35, Description = "Tx #012", Source = checkingAccount2, Recipient = savingAccount, CreationDateTime = new DateTime(2022, 1, 12, 0, 0, 0), ActionDateTime = new DateTime(2022, 1, 14, 0, 0, 0) };
            Transaction transaction4 = new Transaction { Principal = client4, Amount = 10, Description = "Tx #009", Source = savingAccount, Recipient = externalAccount, CreationDateTime = new DateTime(2022, 1, 7, 0, 0, 0), ActionDateTime = new DateTime(2022, 1, 11, 0, 0, 0) };
            Transaction transaction5 = new Transaction { Principal = client4, Amount = 20, Description = "Tx #006", Source = checkingAccount2, Recipient = checkingAccount1, CreationDateTime = new DateTime(2022, 1, 3, 0, 0, 0), ActionDateTime = new DateTime(2022, 1, 7, 0, 0, 0) };
            Transaction transaction6 = new Transaction { Principal = client4, Amount = 50, Description = "Tx #005", Source = checkingAccount1, Recipient = checkingAccount2, CreationDateTime = new DateTime(2022, 1, 2, 0, 0, 0), ActionDateTime = new DateTime(2022, 1, 4, 0, 0, 0) };
            Transaction transaction7 = new Transaction { Principal = client5, Amount = 5, Description = "Tx #002", Source = checkingAccount1, Recipient = savingAccount, CreationDateTime = new DateTime(2022, 1, 1, 0, 0, 0), ActionDateTime = new DateTime(2022, 1, 5, 0, 0, 0) };
            Transaction transaction8 = new Transaction { Principal = client5, Amount = 35, Description = "Tx #003", Source = checkingAccount1, Recipient = checkingAccount2, CreationDateTime = new DateTime(2022, 1, 1, 0, 0, 0), ActionDateTime = new DateTime(2022, 1, 9, 0, 0, 0) };
            Transaction transaction9 = new Transaction { Principal = client5, Amount = 100, Description = "Tx #008", Source = savingAccount, Recipient = checkingAccount2, CreationDateTime = new DateTime(2022, 1, 6, 0, 0, 0) };
            Transaction transaction10 = new Transaction { Principal = client5, Amount = 15, Description = "Tx #011", Source = checkingAccount1, Recipient = savingAccount, CreationDateTime = new DateTime(2022, 1, 11, 0, 0, 0), ActionDateTime = new DateTime(2022, 1, 16, 0, 0, 0) };
            Transaction transaction11 = new Transaction { Principal = client5, Amount = 100, Description = "Tx #013", Source = checkingAccount1, Recipient = savingAccount, CreationDateTime = new DateTime(2022, 1, 13, 0, 0, 0) };
            Transaction transaction12 = new Transaction { Principal = client4, Amount = 15, Description = "Tx #004", Source = checkingAccount2, Recipient = savingAccount, CreationDateTime = new DateTime(2022, 1, 2, 0, 0, 0), ActionDateTime = new DateTime(2022, 1, 3, 0, 0, 0) };
            Transaction transaction13 = new Transaction { Principal = client4, Amount = 15, Description = "Tx #010", Source = savingAccount, Recipient = checkingAccount1, CreationDateTime = new DateTime(2022, 1, 10, 0, 0, 0) };
            Transaction transaction14 = new Transaction { Principal = client4, Amount = 10, Description = "Tx #001", Source = checkingAccount1, Recipient = checkingAccount2, CreationDateTime = new DateTime(2022, 1, 1, 0, 0, 0) };

            Transactions.Add(transaction1);
            Transactions.Add(transaction2);
            Transactions.Add(transaction3);
            Transactions.Add(transaction4);
            Transactions.Add(transaction5);
            Transactions.Add(transaction6);
            Transactions.Add(transaction7);
            Transactions.Add(transaction8);
            Transactions.Add(transaction9);
            Transactions.Add(transaction10);
            Transactions.Add(transaction11);
            Transactions.Add(transaction12);
            Transactions.Add(transaction13);
            Transactions.Add(transaction14);

            SaveChanges();

            Database.CommitTransaction();

            SetActionDateTime();
        }
        private void SetActionDateTime()
        {
            foreach (Transaction transaction in Transactions)
            {
                if (transaction.ActionDateTime.Equals(new DateTime()))
                {
                    transaction.ActionDateTime = transaction.CreationDateTime;
                }
            }
            SaveChanges();
        }
        internal void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
    }
}
