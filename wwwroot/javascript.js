const API_URL = "https://localhost:7048/api/tasks";

async function getTasks() {
    const response = await fetch(API_URL);
    const tasks = await response.json();

    const list = document.getElementById("taskList");
    list.innerHTML = "";

    tasks.forEach(task => {
        const li = document.createElement("li");
        li.textContent = task.title + " - " + (task.isDone ? "Done" : "Not done");

        const deleteBtn = document.createElement("button");
        deleteBtn.textContent = "Delete";
        deleteBtn.onclick = () => deleteTask(task.id);

        const doneBtn = document.createElement("button");
        doneBtn.textContent = "Mark Done";
        doneBtn.disabled = task.isDone; // desactiva si ya está hecho
        doneBtn.onclick = () => markDone(task.id);

        li.appendChild(doneBtn);
        li.appendChild(deleteBtn);
        list.appendChild(li);
    });
}

async function addTask() {
    const input = document.getElementById("taskInput");

    await fetch(API_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            title: input.value,
            isDone: false
        })
    });

    input.value = "";
    getTasks();
}

async function deleteTask(id) {
    await fetch(`${API_URL}/${id}`, {
        method: "DELETE"
    });

    getTasks();
}

async function markDone(id) {
    const response = await fetch(`${API_URL}/${id}`);
    const task = await response.json();

    task.isDone = true;

    await fetch(`${API_URL}/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(task)
    });

    getTasks(); 
}


getTasks();