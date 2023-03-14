using BootCamp.Service;
using BootCamp.Service.Contract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace BootCampDynamoDB
{
    public partial class Form1 : Form
    {

        private int _transactionLevel = 0;
        private IProductService _productService;

        public Form1()
        {
            InitializeComponent();
            InitializeServices();
        }

        private void InitializeServices()
        {
            _productService = new ProductService();
            productType.SelectedIndex = 0;
        }

        private void clearComponent()
        {
            productType.SelectedIndex = 0;
            bookAuthor.Text = string.Empty;
            bookPublishDate.Value = DateTime.Now;
            title.Text = string.Empty;
            movieGenre.Text = string.Empty;
            movieDirector.Text = string.Empty;
            albumArtist.Text = string.Empty;
        }


        private ProductModel getProductModel()
        {
            ProductModel item = null;

            if (productType.Text == "Album")
            {
                item = new AlbumModel()
                {
                    TableName = "Album-Table",
                    ProductType = productType.Text,
                    Title = title.Enabled ? title.Text : null,
                    Artist = albumArtist.Enabled ? albumArtist.Text : null
                };
            }
            else if (productType.Text == "Book")
            {
                item = new BookModel()
                {
                    TableName = "Book-Table",
                    ProductType = productType.Text,
                    Author = bookAuthor.Enabled ? bookAuthor.Text : null,
                    Title = title.Enabled ? title.Text : null,
                    PublishDate = bookPublishDate.Value
                };
            }
            else if (productType.Text == "Movie")
            {
                item = new MovieModel()
                {
                    TableName = "Movie-Table",
                    ProductType = productType.Text,
                    Title = title.Enabled ? title.Text : null,
                    Genre = movieGenre.Enabled ? movieGenre.Text : null,
                    Director = movieDirector.Enabled ? movieDirector.Text : null,
                };
            }

            return item;
        }

        private async void putItemBtn_Click(object sender, EventArgs e)
        {
            var item = getProductModel();
            try
            {
                await _productService.AddProduct(item);
                errorMessage.Text = "item added successfully";
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        private async void getItemBtn_Click(object sender, EventArgs e)
        {
            var item = getProductModel();
            var model = await _productService.ReadProduct(item);
            if (model is BookModel bookModel)
            {
                bookAuthor.Text = bookModel.Author;
                bookPublishDate.Value = bookModel.PublishDate == null ? DateTime.Now : bookModel.PublishDate.Value;
                title.Text = bookModel.Title;
            }
            else if (model is MovieModel movieModel)
            {
                title.Text = movieModel.Title;
                movieGenre.Text = movieModel.Genre;
                movieDirector.Text = movieModel.Director;
            }
            else if (model is AlbumModel albumModel)
            {
                title.Text = albumModel.Title;
                albumArtist.Text = albumModel.Artist;
            }
            else
            {
                errorMessage.Text = "could not find the item";
            }
        }

        private async void deleteItemBtn_Click(object sender, EventArgs e)
        {
            var item = getProductModel();
            await _productService.DeleteProduct(item);
            clearComponent();
            errorMessage.Text = "item deleted successfully";
        }

        private async void createTableBtn_Click(object sender, EventArgs e)
        {
            try
            {
                await _productService.CreateTable("Album-Table", nameof(AlbumModel.Artist), nameof(AlbumModel.Title));
                await _productService.CreateTable("Book-Table", nameof(BookModel.Author), nameof(BookModel.Title));
                await _productService.CreateTable("Movie-Table", nameof(MovieModel.Director), nameof(AlbumModel.Title));
                errorMessage.Text = "Album, Book, and Movie tables created successfully";
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        private void productType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (productType.SelectedIndex)
            {
                case 0: // Album
                    productType.Enabled = true;
                    bookAuthor.Enabled = false;
                    bookPublishDate.Enabled = false;
                    title.Enabled = true;
                    movieGenre.Enabled = false;
                    movieDirector.Enabled = false;
                    albumArtist.Enabled = true;
                    break;
                case 1: // Book
                    productType.Enabled = true;
                    bookAuthor.Enabled = true;
                    bookPublishDate.Enabled = true;
                    title.Enabled = true;
                    movieGenre.Enabled = false;
                    movieDirector.Enabled = false;
                    albumArtist.Enabled = false;
                    break;
                case 2: // Movie
                    productType.Enabled = true;
                    bookAuthor.Enabled = false;
                    bookPublishDate.Enabled = false;
                    title.Enabled = true;
                    movieGenre.Enabled = true;
                    movieDirector.Enabled = true;
                    albumArtist.Enabled = false;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void beginTransactionBtn_Click(object sender, EventArgs e)
        {
            _transactionLevel++;
            _productService.BeginTransaction();
            errorMessage.Text = $"Transaction {_transactionLevel} started successfully.";

            updateTransactionLevelText();
        }

        private async void commitTransactionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                await _productService.CommitTransactionAsync();
                errorMessage.Text = $"Transaction {_transactionLevel} committed successfully.";
                _transactionLevel--;

                updateTransactionLevelText();
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        private void cancelTransactionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.RollbackTransaction();
                errorMessage.Text = $"Transaction {_transactionLevel} rolled back successfully.";
                _transactionLevel--;

                updateTransactionLevelText();
            }
            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        private void attribute2Lbl_Click(object sender, EventArgs e)
        {

        }

        private void bookPublishDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void itemDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateTransactionLevelText()
        {
            beginTransactionBtn.Text = $"Begin Transaction ({_transactionLevel})";
            commitTransactionBtn.Text = $"Commit Transaction ({_transactionLevel})";
            cancelTransactionBtn.Text = $"Rollback Transaction ({_transactionLevel})";

            if (_transactionLevel <= 0)
            {
                commitTransactionBtn.Enabled = false;
                cancelTransactionBtn.Enabled = false;
            }
            else
            {
                commitTransactionBtn.Enabled = true;
                cancelTransactionBtn.Enabled = true;
            }
        }
    }
}
