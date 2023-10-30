using FluentAssertions;
using HelperStockBeta.Domain.Entities;

namespace HelperStockBeta.Domain.Test;
public class ProductUnitTestBase
{
    #region Testes Positivos
    [Fact(DisplayName = "Product name is not null.")]
    public void CreateProduct_withParameters_ResultValid()
    {
        Action action = () => new Product("Product Test", "Melhor produto", 12, 8, "www.google.com.br");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Product with id")]
    public void CreateProduct_withId_ResultValid()
    {
        Action action = () => new Product(1, "Product Test", "Melhor produto", 12, 8, "www.google.com.br");
        action.Should()
            .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
    }
    #endregion

    #region Testes Negativos

    [Fact(DisplayName = "Id negative exception")]
    public void CreatePorduct_NegativeParameterId_ResultException()
    {
        Action action = () => new Product(-1, "Product Test", "Melhor produto", 12, 8, "www.google.com.br");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for id.");
    }

    [Fact(DisplayName = "Name is not null")]
    public void CreateProduct_NameIsNotNull_ResultException()
    {
        Action action = () => new Product("", "Melhor produto", 12, 8, "www.google.com.br");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required.");
    }

    [Fact(DisplayName = "Category short name.")]
    public void CreateProduct_NameIsShort_ResultException()
    {
        Action action = () => new Product("Pr", "Melhor produto", 12, 8, "www.google.com.br");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid short names, minimum 3 characteres.");
    }

    [Fact(DisplayName = "Invalid Description")]
    public void CreateProduct_InvalidDescription_ResultException()
    {
        Action action = () => new Product("Product Teste", "", 12, 8, "www.google.com.br");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description, description is required.");
    }

    [Fact(DisplayName = "Description is short")]
    public void CreateProduct_ShortDescription_ResultException()
    {
        Action action = () => new Product("Product Test", "prod", 12, 8, "www.google.com.br");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid short descriptions, minimum 5 characters.");
    }

    [Fact(DisplayName = "Price is not negative")]
    public void CreateProduct_PriceNegativeInvalid_ResultException()
    {
        Action action = () => new Product("Product Test", "Melhor produto", -12, 8, "www.google.com.br");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for price.");
    }

    [Fact(DisplayName = "Stock is not negative")]
    public void CreateProduct_StockNegativeInvalid_ResultException()
    {
        Action action = () => new Product("Product Test", "Melhor produto", 12, -8, "www.google.com.br");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid negative values for stock.");
    }

    [Fact(DisplayName = "URL longer than 250 characteres ")]
    public void CreateProduct_URLLarge_ResultException()
    {
        Action action = () => new Product("Product Test", "Melhor produto", 12, 8, "https://www.google.com/search?q=tradutor&rlz=1C1GCEU_pt-BRBR1047BR1047&oq=tradutor&gs_lcrp=EgZjaHJvbWUqDwgAEEUYOxiDARixAxiABDIPCAAQRRg7GIMBGLEDGIAEMgYIARAAGAMyCggCEAAYsQMYgAQyDQgDEAAYgwEYsQMYgAQyDQgEEAAYgwEYsQMYgAQyBwgFEAAYgAQyDQgGEAAYgwEYsQMYgAQyDQgHEAAYgwEYsQMYgAQyCggIEAAYsQMYgAQyDQgJEAAYgwEYsQMYgATSAQgxMjIzajBqOagCALACAA&sourceid=chrome&ie=UTF-8");
        action.Should()
            .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid long URL, maximum 250 characteres.");
    }
    #endregion
}