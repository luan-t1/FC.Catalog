using FC.Codeflix.Catalog.Domain.Entity;
using Moq;

namespace FC.Codeflix.Catalog.UnitTests.Application.ListCategories;

[Collection(nameof(ListCategoriesTestFixture))]
public class ListCategoriesTest
{
    private readonly ListCategoriesTestFixture _fixture;

    public ListCategoriesTest(ListCategoriesTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = nameof(List))]
    [Trait("Application", "ListCategories - Use Cases")]
    public async Task List()
    {
        var categoriesExampleList = _fixture.GetExampleCategoriesList();
        var repositoryMock = _fixture.GetRepositoryMock();
        var input = new ListCategoriesInput(
            page: 2,
            perPage: 15,
            search: "search-example",
            sort: "name",
            dir: SearchOrder.Asc
        );
        repositoryMock.Setup(x => x.Search(
            It.IsAny<SearchInput>(
                searchInput.Page == input.Page
                && searchInput.PerPage == input.PerPage
                && searchInput.OrderBy == input.Sort
                && searchInput.Order == input.Dir),
            It.IsAny<CancellationToken>()
            )).ReturnsAsync(new OutputSearch<Category>(
                currentPage: input.Page,
                perPage: input.PerPage,
                items: (IReadOnlyList<Category>) categoriesExampleList,
                total: 70
            ));
        var useCase = new ListCategories(repositoryMock.Object);

        var output = await useCase.Handle(input, CancellationToken.None);

        output.Should().NotBeNull();
        output.


    }

}
