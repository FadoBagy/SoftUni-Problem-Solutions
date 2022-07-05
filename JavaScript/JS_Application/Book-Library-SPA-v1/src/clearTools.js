const allNavs = document.querySelectorAll('#navigation');

const allSectionsEl = document.getElementById('main-content');

export function hideNavs() {
    for (const nav of allNavs[0].children) {
        nav.style.display = 'none';
    }
}

export function hideSections() {
    for (const section of allSectionsEl.children) {
        section.style.display = 'none';
    }
}