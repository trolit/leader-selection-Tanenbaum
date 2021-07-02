<p align="left"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/appLogo.png" alt="App logo" width="130"/></p>

<p align="justify">LSA(Leader Selection Algorithm) is WinForms desktop app that implements ring algorithm election(Tanenbaum's variant) using .NET sockets mechanism. Ring knowledge isn't centralized. Ring synchronization in first turn gathers ring intel and then it's invoker passes collected data to other processes. While synchronization is completed, processes other than leader can ask coordinator if it's still alive or signal priority change. When one or more processes will found leader to be unreachable, election is started. Election message collects intel about available processes and on returning to the process that called it, gets mapped to coordinator message which contains updated ring structure from which new leader is chosen. Note that app was'nt tested on external addresses.</p> 

<br/> Application interface:

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img1.png" alt="App interface 1"/></p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img2.png" alt="App interface 2"/></p>

```
Legend:
- [1] Expands / collapses process log
- [2] Displays credits
- [3] Invokes app given amount of times and initialize every process.
- [4] Shutdowns socket connection.
- [5] Process configuration(ID, source address, following address).
- [6] Sets process priority(can be set before socket initialization).
- [7] Instantiates socket.
- [8] Sends to the neighbour ring synchronization request (needs to be manually called only on single process).
- [9] Controls diagnostic ping tool (not available on ring leader/coordinator).
- [10] Shows current knowledge of the process including ring structure, it's leader and when has been chosen..
```

<h3>Preview</h3>

<p align="justify">Six processes initialized using button signed under [3]. </p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img3.png" alt="App preview 1"/></p>

<br/>

<p align="justify">Result of ring synchronization.</p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img4.png" alt="App preview 2"/></p>

<br/>

<p align="justify">Single process log preview after ring synchronization.</p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img5.png" alt="App preview 3"/></p>

<br/>

<p align="justify">Leader receiving ping requests from :254 and :255 and answering them.  </p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img6.png" alt="App preview 4"/></p>

<br/>

<p align="justify">Election result. Leader and :252 were disconnected on purpose. Unreachable coordinator was detected by :254 and :255 and as a result, two election messages were processed by ring. New coordinator got chosen and dead :252 wasn't considered in updated structure.</p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img7.png" alt="App preview 5"/></p>

<br/>

<p align="justify">Log preview of one of the processes(:254) that started election.</p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img8.png" alt="App preview 6"/></p>

<br/>

App icon made by Becris, https://www.flaticon.com/authors/becris 

Template created on 2/7/2021 <br/> in <a href="https://github.com/trolit/EzGitDoc">EzGitDoc</a>
