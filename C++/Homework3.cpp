#include "iostream"
#include "vector"
#include "cstdlib"
#include "ctime"

using namespace std;

int main() 
{
	setlocale(LC_ALL, "Russian");

	int n;
	cin >> n;

	srand(time(0));

	vector<int> numbers(n);
	for (int i = 0; i < n; i++) 
	{
		numbers[i] = rand() % 100;
	}
	for (int i = 0; i < n; i++)
	{
		cout << endl << numbers[i] << " ";
	}
	return 0;
}