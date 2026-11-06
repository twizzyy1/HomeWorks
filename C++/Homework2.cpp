#include <iostream>
#include <vector>

using namespace std;

int main() {

    vector<int> numbers(8);
    for (int i = 0; i < 8; i++) 
    {
        cin >> numbers[i];
    }

    for (int i = 7; i >= 0; i--) 
    {
        cout << numbers[i] << " ";
    }
    cout << endl;
}
