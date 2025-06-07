document.addEventListener('DOMContentLoaded', () => {
  const form = document.getElementById('registerForm');
  const errorBox = document.getElementById('error');

  form.addEventListener('submit', async (e) => {
    e.preventDefault();

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    try {
      const response = await fetch('/api/auth/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, password }),
      });

      if (response.ok) {
        window.location.href = 'login.html';
      } else {
        const text = await response.json();
        errorBox.innerText = errorData.message || 'Registration failed. Please try again.';
        errorBox.style.display = 'block';
      }
    } catch (error) {
      errorBox.innerText = 'An error occurred. Please try again later.';
      errorBox.style.display = 'block';
    }
  });
});
