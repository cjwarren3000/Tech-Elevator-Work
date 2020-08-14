<template>
    <div>
        <aside>
                <img src="../assets/images/Services.jpg" alt="A squirrel taking shelter inside a feeder" />
                <cite>Photo by Joakim Honkasalo on Unsplash</cite>
                <blockquote>
                    A certain someone told me you had a problem you needed help with discretely. I can help. <cite>- Sally the Squirrel</cite>
                </blockquote>
            </aside>
            <main>
                <section id="opening">
                    <h1>Services</h1>
                    <p>Sally's isn't <em>just</em> about interview questions. We also offer a wide variety of professional
                        services to help augment our income. Er, I mean, provide value to you, the customer!</p>
                    <h2>Available Services</h2>
                    <p>Take a look at our valuable services:</p>
                    <table>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Name</th>
                                <th>Price</th>
                                <th>Min Hours</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th>COMPL</th>
                                <td>We get your code to compile. By force, if necessary. *</td>
                                <td>$99 / hour</td>
                                <td>1</td>
                            </tr>
                            <tr>
                                <th>HR</th>
                                <td>We 'handle' the HR interview for you, so you can keep prepping for the technical. *</td>
                                <td>$35 / hour</td>
                                <td>3</td>
                            </tr>
                            <tr>
                                <th>SOCIAL</th>
                                <td>We promote you on social media.</td>
                                <td>$18 / hour</td>
                                <td>1</td>
                            </tr>
                            <tr>
                                <th>WTYPRT</th>
                                <td>We take a glance at your code exclaim <q>Well, there's your problem right
                                        there!</q>. **</td>
                                <td>$42 / hour</td>
                                <td>1</td>
                            </tr>
                        </tbody>
                    </table>
                    <p>
                        <small>* - Sally the Squirrel, Tech Elevator, and its staff do not condone
                            violent, criminal, or unethical behavior of any sort. See <router-link to="About">site
                                disclaimer</router-link> for more.</small>
                    </p>
                    <p>
                        <small>** - WTYPRT service should not be construed as meaning that we will actually <em>fix</em>
                            your problem or that the problem we point out is actually real.</small>
                    </p>
                </section>

                <section id="closing">
                    <h2>Request Services</h2>
                    <p>If you see any service you'd like to pay for or have additional questions, feel free to <router-link to="Contact">contact us</router-link>.</p>
                </section>
            </main>        
    </div>
</template>

<style scoped>
/* Tech Elevator Colors

Dark Gray:  #3B3E42
Blue:       #00ADEE
Green:      #8CC63F
Light Gray: #999999
White:      #FFFFFF
Orange:     #F6931D
Purple:     #363E8B
Gold:       #FFCB48
Red:        #c63f3f
*/

/* Table Styling */
table {
    border: 2px solid #8CC63F;
    text-shadow: #999999 1px 1px;
    background-color: #999999;
    border-collapse: collapse;
}

table thead {
    background-color: #3B3E42;
    color: white;
}

thead th {
    color: white;
    padding: 0.25rem 0.5rem;
}

tbody {
    color: white;
}

tbody th {
    color: #F6931D;
    background-color: white;
    text-shadow: #58595a 1px 1px;
    padding-right: 0.5rem;
}

td {
    padding: 0.25rem 0.5rem;
    text-shadow: #3B3E42 1px 1px;
}

/* Alternating rows should use a different background */
tr:nth-child(even) {
    background-color: #58595a;
}

/* Hovered rows should use a different background */
tbody tr:hover {
    background-color: #F6931D;
}

img:hover {
    src: "assets/images/SquirrelPhone.jpg"
}
</style>