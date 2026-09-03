# GraML
a tool for analyzing n-grams and generating text based on the n-gram models

<img width="667" height="690" alt="" src="https://github.com/user-attachments/assets/f748d22e-eb8f-439e-b160-3ca9d9ef8b24" />

### How to start:

1. Open the application.
2. After opening the application, select a plain text file to load under _Select text file_. This text file can be a fairy tale, a lengthy legal text, or a passage from the Bible; the longer the text, the better the resulting text model.
3. Select the length of the N-gram variants to be determined under _N-Gram_. A greater length yields a better resulting text model, though processing takes longer.
4. Once the token list has been generated on the left, calculated text metrics appear on the right.
5. To create the resulting text model, click the _Generate model text_ button. The text model is then generated; the longer the total output length, the longer the generation process may take.

### Known Issues

- The GUI may still freeze during prolonged processing, as the processing has not yet been optimized.
- Handling of special characters is not yet adequate.
- Beyond a certain n-gram length, repetitions of longer word sequences occur. This is due to a bug that has not yet been identified.

![visitors](https://visitor-badge.laobi.icu/badge?page_id=GraML)
