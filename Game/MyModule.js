export const myFunction1 = () => {
  return "This is function 1 from my module";
}

export const myFunction2 = () => {
  return "This is function 2 from my module";
}

const wait = (milliseconds) => new Promise(resolve => {
  setTimeout(() => resolve(), milliseconds);
});

export const asyncFunction = async () => {
  setText("This is a text");
  await wait(5000);
  setText("And now it's changed after await");
};
