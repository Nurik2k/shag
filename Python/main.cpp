#include bits/stdc++.h
#include iostream

#define mk make_pair
#define pb push_back
#define ll long long
#define ull unsigned long long
#define endl '\n'
#define ff first
#define ss second
#define sz size()
#define all(x) x.begin(),x.end()

#define IOS ios::sync_with_stdio(0);cin.tie(0);cout.tie(0)


using namespace std;

const double pi = acos(-1.L);
const int N = 1e6 + 7, ML = 1e6 + 1, MOD = 1e9 + 7;
const int INF = INT_MAX;


bool was[100000];


pair<int, pair<int, int> > a[N];
void solution()
{   
    int n, m;
    cin>>n>>m;
    string s[40];
    string ap = "vika";
    int l  = 0;
    for(int i = 0; i<n; i++){
        
        cin>>s[i];
        
    }
    for(int i = 0; i<n; i++){
        for(int j = 0; j < m; j++){
                if(s[i][j] == ap[l])
                    l++;
        }
    }
    if(l == 4){
        cout<<"YES";
    }
    else
        cout<<"NO";
    
}

int main() {
    IOS;
    /*freopen("e.in", "r", stdin);
    freopen("e.out", "w", stdout);
    ifstream ifst("input.txt");
    ofstream ofst("output.txt");*/
    int qq;
    cin >> qq;
    while (qq--) {
        solution();
    }
    return 0;
}