import { useEffect, useState } from "react"
import { Plus, Trash2, User } from "lucide-react"
import { Button } from "@/components/ui/button"
import {
    Dialog,
    DialogContent,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
} from "@/components/ui/dialog"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import type { Person } from "@/types/person"
import { PeopleService } from "@/services/people.service"
import { birthDateFromAge } from "@/lib/date"
import { toast } from "sonner"

export default function People() {
    const [people, setPeople] = useState<Person[]>([])
    const [loading, setLoading] = useState(true)
    const [name, setName] = useState("")
    const [age, setAge] = useState("")
    const [open, setOpen] = useState(false)


    async function loadPeople() {
        try {
            setLoading(true)
            const data = await PeopleService.getAll()
            setPeople(data)
        } finally {
            setLoading(false)
        }
    }

    async function handleCreate() {
        const birthDate = birthDateFromAge(Number(age))

        await PeopleService.create({ name, birthDate })

        await loadPeople()

        setOpen(false)
        setName("")
        setAge("")

        toast.success("Person created successfully")
    }


    async function handleDelete(id: number) {
        await PeopleService.delete(id)
        setPeople(prev => prev.filter(p => p.id !== id))
    }

    useEffect(() => {
        loadPeople()
    }, [])

    if (loading) {
        return <div className="text-muted-foreground">Loading people...</div>
    }

    return (
        <div className="space-y-6">
            <div className="flex items-center justify-between">
                <Dialog open={open} onOpenChange={setOpen}>
                    <DialogTrigger asChild>
                        <Button className="gap-2">
                            <Plus className="w-4 h-4" />
                            New person
                        </Button>
                    </DialogTrigger>

                    <DialogContent>
                        <DialogHeader>
                            <DialogTitle>New person</DialogTitle>
                        </DialogHeader>

                        <div className="space-y-4 mt-4">
                            <div className="space-y-2">
                                <Label>Name</Label>
                                <Input value={name} onChange={e => setName(e.target.value)} />
                            </div>

                            <div className="space-y-2">
                                <Label>Age</Label>
                                <Input
                                    type="number"
                                    min={0}
                                    value={age}
                                    onChange={e => setAge(e.target.value)}
                                />
                            </div>

                            <Button className="w-full mt-2" onClick={handleCreate}>
                                Create person
                            </Button>
                        </div>
                    </DialogContent>
                </Dialog>
            </div>

            <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                {people.map(person => (
                    <div
                        key={person.id}
                        className="bg-card border border-border rounded-xl p-4 shadow-sm flex items-start justify-between"
                    >
                        <div className="flex gap-3">
                            <div className="w-10 h-10 rounded-lg bg-primary/10 text-primary flex items-center justify-center">
                                <User className="w-5 h-5" />
                            </div>

                            <div>
                                <p className="font-medium">{person.name}</p>
                                <p className="text-sm text-muted-foreground">
                                    Age: {person.age}
                                </p>
                            </div>
                        </div>

                        <button
                            onClick={() => handleDelete(person.id)}
                            className="text-muted-foreground hover:text-destructive transition"
                        >
                            <Trash2 className="w-4 h-4" />
                        </button>
                    </div>
                ))}
            </div>
        </div>
    )
}
