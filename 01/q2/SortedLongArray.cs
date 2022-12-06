public class SortedLongArray{
    private readonly int _size;
    private long[] arr;
    public SortedLongArray(int size)
    {
        _size = size;
        arr = new long[size];
    }

    public void Add(long val){
        int shiftIndex = -1;
        for(int i=0; i<_size; i++){
            if(val > arr[i]){
                shiftIndex = i;
                break;
            }
        }
        
        if(shiftIndex > -1){
            for(int i= _size-1; i>shiftIndex; i--){
                arr[i] = arr[i-1];
            }
            arr[shiftIndex] = val;
        }
    }

    public long? GetAtIndex(int index){
        if(index<0 || index>=_size)
            return null;
        return arr[index];
    }
}