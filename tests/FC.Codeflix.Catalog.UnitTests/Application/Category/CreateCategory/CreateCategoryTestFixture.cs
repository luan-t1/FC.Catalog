﻿using FC.Codeflix.Catalog.Application.Interfaces;
using FC.Codeflix.Catalog.Application.UseCases.Category.CreateCategory;
using FC.Codeflix.Catalog.Domain.Repository;
using FC.Codeflix.Catalog.UnitTests.Application.Category.Common;
using FC.Codeflix.Catalog.UnitTests.Common;
using Moq;

namespace FC.Codeflix.Catalog.UnitTests.Application.Category.CreateCategory;

[CollectionDefinition(nameof(CreateCategoryTestFixture))]
public class CreateCategoryTestFixtureCollection : ICollectionFixture<CreateCategoryTestFixture>
{

}
public class CreateCategoryTestFixture : CategoryUseCasesBaseFixture
{

    public CreateCategoryInput GetInput()
        => new(
            GetValidCategoryName(),
            GetValidCategoryDescription(),
            getRandomBoolean()
            );

    public CreateCategoryInput GetInvalidInputShortName()
    {
        var invalidInputShortName = GetInput();
        invalidInputShortName.Name = invalidInputShortName.Name.Substring(0, 2);
        return invalidInputShortName;
    }

    public CreateCategoryInput GetInvalidInputTooLongName()
    {
        var invalidInputTooLongName = GetInput();
        var tooLongNameForCategory = Faker.Commerce.ProductName();
        while (tooLongNameForCategory.Length <= 255)
        {
            tooLongNameForCategory = $"{tooLongNameForCategory}{Faker.Commerce.ProductName()}";
        }
        invalidInputTooLongName.Name = tooLongNameForCategory;

        return invalidInputTooLongName;
    }

    public CreateCategoryInput GetInvalidInputDescriptionNull()
    {
        var invalidInputDescriptionNull = GetInput();
        invalidInputDescriptionNull.Description = null!;
        return invalidInputDescriptionNull;
    }

    public CreateCategoryInput GetInvalidInputTooLongDescription()
    {
        var invalidInputTooLongDescription = GetInput();
        var tooLongDescriptionForCategory = Faker.Commerce.ProductDescription();
        while (tooLongDescriptionForCategory.Length <= 10_000)
        {
            tooLongDescriptionForCategory = $"{tooLongDescriptionForCategory}{Faker.Commerce.ProductDescription()}";
        }
        invalidInputTooLongDescription.Description = tooLongDescriptionForCategory;
        return invalidInputTooLongDescription;
    }
}
