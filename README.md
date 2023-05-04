# Sliding
Data una stringa formata solo da cifre dobbiamo calcolare il prodotto più grande per una sua sottostringa contigua di cifre di lunghezza N.

Possiamo risolvere questo problema utilizzando un ciclo che gira la lunghezza della stringa di numeri sottratto il valore di **span**. 

Come prima cosa dichiariamo una lista che utilizzeremo per aggiungere i prodotti di tutti gli intervalli consecutivi possibili nella stringa.
```cs
var things = new List<int>();
```

```cs
for(int i = 0; i <= digits.Length - span; i++){
	string fullNum = digits.Substring(i, span);
	int product = 1;
	
	foreach(char c in fullNum){
		product *= int.Parse(c.ToString());
	}
	things.Add(product);
}
return things.Max();
```
Utilizziamo *Substring()* che è un metodo dell'oggetto string che accetta due argomenti che corrispondono all'intervallo di cui vogliamo fare il prodotto.

Utilizziamo un *foreach()* per scorrere ogni numero della stringa estratta dall'intervallo e moltiplicarli tra loro e infine aggiungiamo questo prodotto alla lista.

Per ritornare il numero maggiore tra questi prodotti che abbiamo fatto utilizziamo il metodo *Max()* delle liste che come dice il nome prende il numero massimo nella lista.

----
Dobbiamo però fare anche dei controlli per evitare che il codice vada in crisi in caso che ci venga dato un input sbagliato.
```cs
if(span > 0 && digits.Length == 0)
	throw new System.ArgumentException();
```
Questo controllo avviene in caso span è maggiore di zero e la lunghezza massima della nostra stringa è pari a zero in questo caso tirerà un eccezione il programma.

```cs
if(span == 0)
	return 1;
```
Questo controllo lo facciamo in caso che span sia pari a zero e in questo caso ritorniamo 1.

```cs
if(digits.Length - span < 0 || span < 0)
	throw new System.ArgumentException();
```
Quest'altro controllo lo facciamo per il caso in cui **span** è maggiore della lunghezza della stringa oppure che **span** sia minore di zero.

```cs
foreach( char c in digits ){
	if(!char.IsNumber(c)){
		throw new System.ArgumentException();
	}
}
```
Quest'ultimo controllo con un *foreach()* serve a controllare che tutti i caratteri presenti nella stringa siano effettivamente dei numeri altrimenti tirerà un eccezione.