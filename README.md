# Markov Ngrams

Based on [Using a Markov chain to generate readable nonsense with 20 lines of Python](https://benhoyt.com/writings/markov-chain/). // Nov 2023

## Outputs

Lewis Carroll. Alice's adventures in Wonderland

```shell
> cat .\alice.txt | .\MarkovNgrams.exe
```

"Just at this moment Alice felt a little more conversation with her face like the look of the shepherd boy--and the sneeze of the creature, but on second thoughts she decided on going into the wood."

"There's no pleasing them!'   Alice replied in an agony of terror."

## Ngrams for Alice

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

Words are chosen randomly. If words are repeated more often, they will be appear more often.

```text
before the  : trial's | end | trial's | officer
```

`before the trial's` happens twice often than `before the end` or `before the officer`.
