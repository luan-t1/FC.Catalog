namespace FC.Codeflix.Catalog.UnitTests.Application.ListCategories;

[Collection(nameof(ListCategoriesTestFixture))]
public class ListCategoriesTest
{
    private readonly ListCategoriesTestFixture _fixture;

    public ListCategoriesTest(ListCategoriesTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = nameof(ListCategories))]
    [Trait("Application", "ListCategories - Use Cases")]
    public async Task ListCategories()
    {
        // Arrange
        var useCase = _fixture.GetListCategoriesUseCase();
        var input = _fixture.GetListCategoriesInput();

        // Act
        var output = await useCase.Handle(input, CancellationToken.None);

        // Assert
        _fixture.AssertListCategoriesOutput(output);
    }

}
