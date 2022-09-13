function loadRepos() {
	let reposElement = document.getElementById('repos');
	let usernameElement = document.getElementById('username');

	let baseUrl = 'https://api.github.com/users';
	fetch(`${baseUrl}/${usernameElement.value}/repos`)
		.then(res => res.json())
		.then((data) => {
			reposElement.innerHTML = '';
			for (const repos of data) {
				let newListItem = document.createElement('li');
				let newAnchorItem = document.createElement('a');
				newAnchorItem.href = repos.html_url;
				newAnchorItem.textContent = repos.full_name;
				newListItem.appendChild(newAnchorItem);
				reposElement.appendChild(newListItem);
			}
		})
		.catch(err => reposElement.innerHTML = 'Not Found');
}