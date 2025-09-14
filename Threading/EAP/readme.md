EAP - event-based asynchronus pattern provides a simple means by which classes can offer multithreading capability without consumers needing to explicitly start or manage threads.

Essentially the pattern is this: a class offers a family of members that internally manage multithreading, similar to the following (the highlighted sections indicate code that is part of the pattern):

// These members are from the WebClient class:

public byte[] DownloadData (Uri address); // Synchronous version
public void DownloadDataAsync (Uri address);
public void DownloadDataAsync (Uri address, object userToken);
public event DownloadDataCompletedEventHandler DownloadDataCompleted;

public void CancelAsync (object userState); // Cancels an operation
public bool IsBusy { get; } // Indicates if still running
