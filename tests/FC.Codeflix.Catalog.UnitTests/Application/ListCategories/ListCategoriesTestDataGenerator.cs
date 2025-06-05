using FC.Codeflix.Catalog.Application.UseCases.Category.ListCategories;

namespace FC.Codeflix.Catalog.UnitTests.Application.ListCategories;

public class ListCategoriesTestDataGenerator
{
    public static IEnumerable<object[]> GetInputsWithoutAllParameter(int times = 10)
    {
        var fixture = new ListCategoriesTestFixture();

        var inputExample = fixture.GetExampleInput();
        for(int i = 0;i < times; i++)
        {
            switch (i % 5)
            {
                case 0:
                    yield return new object[]{ ListCategoriesInput() }; 
                    break;
                case 1:
                    yield return new object[] { ListCategoriesInput(inputExample.Page) };
                    break;
                case 2:
                    yield return new object[] { ListCategoriesInput(inputExample.Page,inputExample.PerPage) };
                    break;
                case 3:
                    yield return new object[] { ListCategoriesInput(inputExample.Page, inputExample.PerPage, inputExample.Search) };
                    break;
                case 4:
                    yield return new object[] { ListCategoriesInput(inputExample.Page, inputExample.PerPage, inputExample.Search, inputExample.Sort) };
                    break;
                default:
            }
        }
    }
}
