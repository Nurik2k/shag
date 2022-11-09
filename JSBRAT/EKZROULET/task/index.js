document.addEventListener('DOMContentLoaded', () => {
  const state = {
    looses: 0,
    wins: 0,
    number: 0,
    value: null,
  };

  const inputs = document.querySelectorAll('.input-radio');
  const btn = document.querySelector('.btn');
  const numberText = document.querySelector('.number');

  inputs.forEach((input) => {
    input.addEventListener('click', (e) => {
      state.value = e.target.value;
      btn.disabled = false;
    });
  });

  btn.addEventListener('click', (e) => {
    state.number = Math.floor(Math.random() * 37);
    numberText.textContent = state.number;

    if (state.number == 0) {
      numberText.style.color = 'green';
    } else if (isEven(state.number)) {
      numberText.style.color = 'red';
    } else {
      numberText.style.color = 'black';
    }

    if (state.value === 'red' && isEven(state.number)) {
      state.wins += 1;

      if (state.wins === 10) {
        setTimeout(() => {
          alert(`Вы победили ${state.wins} раз.`);
          clearState();
        }, 250);
      } else {
        setTimeout(() => alert(`Побед ${state.wins}`), 250);
      }
    } else if (state.value === 'even' && isEven(state.number)) {
      state.wins += 1;
      if (state.wins === 10) {
        setTimeout(() => {
          alert(`Вы победили ${state.wins} раз.`);
          clearState();
        }, 250);
      } else {
        setTimeout(() => alert(`Побед ${state.wins}`), 250);
      }
    } else if (state.value === 'black' && !isEven(state.number)) {
      state.wins += 1;
      if (state.wins === 10) {
        setTimeout(() => {
          alert(`Вы победили ${state.wins} раз.`);
          clearState();
        }, 250);
      } else {
        setTimeout(() => alert(`Побед ${state.wins}`), 250);
      }
    } else if (state.value === 'odd' && !isEven(state.number)) {
      state.wins += 1;
      if (state.wins === 10) {
        setTimeout(() => {
          alert(`Вы победили ${state.wins} раз.`);
          clearState();
        }, 250);
      } else {
        setTimeout(() => alert(`Побед ${state.wins}`), 250);
      }
    } else {
      state.looses += 1;
      if (state.looses === 10) {
        setTimeout(() => {
          alert(`Вы проиграли ${state.looses} раз.`);
          clearState();
        }, 250);
      } else {
        setTimeout(() => alert(`Проигрыш ${state.looses}`), 250);
      }
    }
  });

  function isEven(num) {
    return num % 2 === 0;
  }

  function clearState() {
    btn.disabled = true;
    inputs.forEach((input) => {
      input.checked = false;
    });
    state.wins = 0;
    state.looses = 0;
  }
});
