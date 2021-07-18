<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/appLogo.png" alt="App logo" width="200"/></p>
<h3 align="center">DISTRIBUTED SYSTEMS</h3>
<h4 align="center">Leader election algorithm (ring topology, Tanenbaum's variant) implementation<br/>made for a subject from Military University of Technology</h4>

<hr/>

<pre>
- Ring knowledge <strong>isn't centralized</strong>. Therefore ring synchronization in first turn gathers ring intel
and then it's invoker passes collected data to other processes.
- While synchronization is completed, <strong>processes(other than leader) can ask coordinator if it's still 
"alive"</strong> or signal priority change. 
- When one or more processes find leader to be unreachable, election(s) are raised. 
- Election message collects intel about available processes and on returning to the process that called 
it, gets mapped to coordinator message which contains updated ring structure from which new leader 
is picked.
- <strong>For more than 1 election happening at same time</strong>, every process selects same leader on coordinator 
message due to descending data ordering through priority property.
- App not tested on external addresses.
</pre>

<h4>Application interface</h4>
<hr/>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img1.png" alt="App interface 1" height="350"/></p>

```
- [1] Expands / collapses process log
- [2] Displays credits
- [3] Invokes app given amount of times and initialize every process.
- [4] Shutdowns socket connection.
- [5] Process configuration(ID, source address, following address).
- [6] Sets process priority(can be set before socket initialization).
- [7] Instantiates socket.
- [8] Sends to the neighbour ring synchronization request (needs to be manually called only on single process).
```

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img2.png" alt="App interface 2" height="350"/></p>

```
- [9] Controls diagnostic ping tool (not available on ring leader/coordinator).
- [10] Shows current knowledge of the process including ring structure, it's leader and when has been chosen..
```


<h4>Demonstration (cases)</h4>
<hr/>

<p align="justify">a) Six processes initialized using button signed under [3]. </p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img3.png" alt="App preview 1" height="350"/></p>

<br/>

<p align="justify">b) Result of ring synchronization. Every process obtained ring structure and leader identity.</p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img4.png" alt="App preview 2"/></p>

<br/>

<p align="justify">c) One of the processes(:253) log preview after ring synchronization. You can notice that :253 is responsible for calling synchronization and after collecting ring structure, sending knowledge to consequent(:254) and finally removing ring structure message on return. </p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img5.png" alt="App preview 3"/></p>

<br/>

<p align="justify">d) Process :250(current ring leader) receiving ping requests from :254 and :255 and answering them.  </p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img6.png" alt="App preview 4"/></p>

<br/>

<p align="justify">e) Election result. Leader(:250) and :252 were disconnected on purpose(processes with red rectangle). Unreachable coordinator was detected by :254 and :255(blue rectangles) and as a result, two election messages were processed by ring. New coordinator got chosen and note that "dead" :252 wasn't considered in updated structure.</p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img7.png" alt="App preview 5"/></p>

<br/>

<p align="justify">f) Log preview of one of the processes(:254) that started election. You can see that :254 processed 2 election messages, the one that it initiated and secondary raised by process with Id: P-0005.</p>

<p align="center"><img src="https://raw.githubusercontent.com/trolit/leader-selection-Tanenbaum/images/images/img8.png" alt="App preview 6"/></p>

<br/>

<strong>Note</strong> that when coordinator is being pinged by other process/processes and gets closed without toggling "disconnect" button, an exception in the messagebox will occur. Therefore it's highly recommended to use "Disconnect" button to close socket properly and simulate dead coordinator in order to test election stage. 

<br/>
<br/.

App icon made by Becris, https://www.flaticon.com/authors/becris 

README template created on 2/7/2021 <br/> in <a href="https://github.com/trolit/EzGitDoc">EzGitDoc</a>
