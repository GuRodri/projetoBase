using FluentAssertions;
using HelperStockBeta.Domain.Entities;
using System.Security.AccessControl;

namespace HelperStockBeta.Domain.Test
{
    #region Casas de teste positivos
    public class CategoryUnitTestBase
    {
        [Fact(DisplayName = "Category name id not null")]
        public void CreateCategory_WithValidParameters_ResultValid()
        {
            Action action= () => new Category(1, "Categoria Teste");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
                            
        }

        [Fact(DisplayName = "Category not present id parameter")]
        public void CreateCategory_IdParameterLess_ResultValid()
        {
            Action action = () => new Category("Categoria Teste");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();

        }
        #endregion
        #region Casas de testes negativos

        [Fact(DisplayName = "Id negative execption.")]
        public void CreateCategory_NegativeParameterId_ResultException()
        {
            Action action = () => new Category(-1, "Categoria Teste");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Identification is positive values!");
        }

        [Fact(DisplayName = "Name is Category null.")]
        public void CreateCategory_NameParameterId_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }

        [Fact(DisplayName = "Name short for Category null.")]
        public void CreateCategory_NameParameterShort_ResultException()
        {
            Action action = () => new Category(1, "ca");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is minimum 3 charecters");
        }

        #endregion
    }
}

