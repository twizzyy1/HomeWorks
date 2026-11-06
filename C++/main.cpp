#include <iostream>
#include <vector>

using namespace std;

int main() 
{
    setlocale(LC_ALL, "Russian");

    int n;
    cin >> n;

    vector<int> numbers(n);
    for (int i = 0; i < n; i++) 
    {
        cin >> numbers[i];
    }

    int x;
    cin >> x;

    int index = -1;
    for (int i = 0; i < n; i++) 
    {
        if (numbers[i] == x) 
        {
            index = i;
            break;
        }
    }

    cout << index << endl;

    return 0;
}
