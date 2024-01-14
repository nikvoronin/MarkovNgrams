# Markov Ngrams

Based on [Using a Markov chain to generate readable nonsense with 20 lines of Python](https://benhoyt.com/writings/markov-chain/). November 2023

## Outputs

```shell
> cat .\alice.txt | .\MarkovNgrams.exe
Free Software Foundation and Richard M.

> cat .\alice.txt | .\MarkovNgrams.exe
There's no pleasing them!'   Alice replied in an agony of terror.
```

## Ngrams for Alice

Lewis Carroll. Alice's adventures in Wonderland

```text
the jury    : eagerly | asked. | had | wrote | consider
before the  : trial's | end | trial's | officer
on his      : flappers, | spectacles | spectacles. | knee, | slate
So they     : went | sat | began | got | had | got | couldn't

the Gryphon,: half | and | `she | and | before | sighing | `you | with | `that | and | and, | the | and

the Gryphon.: Alice | `It's | `--you | `Of | `Then, | `Back | `We | `I've | `The | `Do | `I | `It | `How | `Well, | `They

the Gryphon : answered, | said | went | never | remarked | interrupted | replied | went | replied | added | in | as | hastily. | repeated | went | said, | only | whispered
```

## Repeated but why?

Words choose random. If words repeat often then they will appear more often.

```text
before the  : trial's | end | trial's | officer
```

`before the trial's` happens twice often than `before the end` or `before the officer`.
